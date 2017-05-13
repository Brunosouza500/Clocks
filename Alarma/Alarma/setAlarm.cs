using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Threading;

using static Alarma.Config.status_t;


namespace Alarma
{
    public partial class frmSetAlarm : Form
    {
        public frmSetAlarm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Leave current form
            this.Close();
        }

        private void btnSetAlarm_Click(object sender, EventArgs e)
        {
            // Create status st.
            Config.status_t st;

            // Create Logic class (we will use its method(s)):
            Logic LogicClass = new Logic();

            // Get date in a DateTime type:
            DateTime alarmDate = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, dtpFecha.Value.Day,0,0,0);

            // Make sure arguments are valid:
            if (( st = LogicClass.validateArguments(Config.FORM_ALARM, ref alarmDate, txbHora.Text, txbMinuto.Text, txbSegundo.Text)) != OK)
            {
                LogicClass.displayError(st);
                return;
            }


            // Create alarm class
            MessageBox.Show("hour: " + alarmDate.Hour + ". minute: " + alarmDate.Minute + ". second: " + alarmDate.Second);
            Alarm _Alarm = new Alarm(alarmDate.Hour, alarmDate.Minute, alarmDate.Second, alarmDate.Day, alarmDate.Month, alarmDate.Year, cbxMelodia.Text);

            // Store alarm:
            try
            {
                if ((st = LogicClass.storeAlarm(_Alarm)) != OK)
                {
                    LogicClass.displayError(st);
                    return;
                }

            } catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set up the timer:

            if ((st = LogicClass.setTimer(_Alarm, alarmDate)) != OK)
            {
                LogicClass.displayError(st);
                return;
            }

        }

        private void cbxMelodia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSetAlarm_Load(object sender, EventArgs e)
        {
            Logic LogicClass = new Alarma.Logic();

            List < Sound > soundList = new List<Sound>();

            soundList = LogicClass.getSoundList(Config.FILEPATH_ALARM_SOUND);

            var dataSource = soundList;

            cbxMelodia.DataSource = dataSource;
            cbxMelodia.DisplayMember = "Name";

            cbxMelodia.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}
