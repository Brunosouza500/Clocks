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
            // Create Logic class (we will use its method(s)):
            Logic LogicClass = new Logic();

            // Get date in a DateTime type:
            DateTime AlarmDate = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, dtpFecha.Value.Day);

            // Error message
            string errorMessage = "";

            // Date value of alarm = Will be useful later.
            DateTime alarmDate = new DateTime();

            // Make sure arguments are valid:
            try
            {
                LogicClass.validateArguments(Config.FORM_ALARM, txbHora.Text, txbMinuto.Text, txbSegundo.Text, AlarmDate, out errorMessage, out alarmDate);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Something is wrong, please try again");

            }

            // Give error message and return if there is one
            if (errorMessage != String.Empty)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            // Create alarm class
            Alarm _Alarm = new Alarm(Int32.Parse(txbHora.Text), Int32.Parse(txbMinuto.Text), Int32.Parse(txbSegundo.Text), AlarmDate.Day, AlarmDate.Month, AlarmDate.Year, cbxMelodia.Text);

            // Create file to store alarm:
            try
            {
                LogicClass.storeAlarm(_Alarm);

            } catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set up the timer:
            System.Threading.TimerCallback cb = new System.Threading.TimerCallback( _Alarm.trigger );

            System.Threading.Timer timer = new System.Threading.Timer(cb);

            DateTime now = DateTime.Now;
            DateTime dateAlarm = alarmDate;

            if(now > dateAlarm)
            {
                dateAlarm.AddDays(1.0);
            }
            int msUntilAlarm = (int)(dateAlarm - now).TotalMilliseconds;

            timer.Change(msUntilAlarm, Timeout.Infinite);







        }


    }
}
