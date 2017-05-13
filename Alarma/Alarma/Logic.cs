using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using static Alarma.Config.status_t;

namespace Alarma
{
    public class Logic
    {

        public Config.status_t validateArguments(string form, ref DateTime alarmDate, params string[] parameters)
        {
            int count;
            Config.status_t st;

            if ((st = this.formExists(form, out count)) != OK)
            {

                return st;
            }

            if ((st = this.validate(Config.FORMS[count], ref alarmDate, parameters)) != OK)
            {
                return st;
            }

            return OK;

        }

        private Config.status_t validate(string form, ref DateTime alarmDate, params string[] parameters)
        {
            if (form == Config.FORM_ALARM)
            {
                string hour = parameters[0];
                string minute = parameters[1];
                string second = parameters[2];

                // "mon/day/year hour:min:sec"
                string dateString = alarmDate.Day + "/" + alarmDate.Month + "/" + alarmDate.Year + " " + hour + ":" + minute + ":" + second;
                MessageBox.Show(dateString);
                DateTime dateValue = new DateTime();

                if ((DateTime.TryParse(dateString, out dateValue)) && (!hasEmptyString(hour, minute, second)))
                {
                    alarmDate = dateValue;
                    // Let's update alarmDate with hour, min and second of date Value: Because when subroutine ends dateValue will die.
                    //alarmDate.AddHours(Convert.ToDouble(dateValue.Hour));
                    //alarmDate.AddMinutes(Convert.ToDouble(dateValue.Minute));
                    //alarmDate.AddSeconds(Convert.ToDouble(dateValue.Second));

                    // Alarm must be after current time
                    if (DateTime.Now > dateValue)
                    {
                        return ERROR_TIME_ALARM_BEFORE_NOW;
                    }
                    return OK;
                }

            }
            else if (form == Config.FORM_MENU)
            {
                // Menu form case


            }
            else
            {
                // Default

            }

            return ERROR_LOGIC_VALIDATE;
        }

        private Config.status_t formExists(string form, out int count)
        {
            bool formExists = false;
            count = 0;

            // Check if string form is valid:
            foreach (var ConfigForm in Config.FORMS)
            {

                if (ConfigForm == form) { formExists = true; break; }
                count++;

            }

            // No form in config coincides with the given string:
            if (!formExists)
            {
                return ERROR_FRM_NOT_EXIST;
            }

            return OK;
        }

        private bool hasEmptyString(params string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == String.Empty) { return true; }
            }

            return false;
        }



        public Config.status_t storeAlarm(Alarm alarm)
        {
            // Create file handler, Logic has no storeAlarm method because it is not pertinent.
            Filehandler fileH = new Filehandler();
            Config.status_t st = ERROR_UKNOWN;

            // Call fileHandler to handle storage in files.
            try
            {
                if ((st = fileH.storeAlarm(alarm)) != OK)
                {
                    return st;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return st;


        }

        public Config.status_t setTimer(Alarm alarm, DateTime alarmDate)
        {
            Config.status_t st;

            // Call time handler:
            Timehandler timeH = new Timehandler();

            st = timeH.setAlarm(alarm, alarmDate);

            return st;
        }

        public List<Sound> getSoundList(string filepath)
        {
            Filehandler fileH = new Filehandler();

            return fileH.getSoundList(filepath);

        }

        public void displayError(Config.status_t st)
        {

            switch (st)
            {

                case ERROR_FRM_NOT_EXIST:
                    MessageBox.Show("Error", "Please contact the administrator. Your program needs fixing.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case ERROR_LOGIC_VALIDATE:
                    MessageBox.Show("Argument Error", "The information provided is wrong.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ERROR_TIME_ALARM_BEFORE_NOW:
                    MessageBox.Show("Alarm Error", "The alarm cannot be before the current time.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ERROR_UKNOWN:
                    // Don't handle this
                    break;

                default:
                    //
                    MessageBox.Show("Error", "An error has occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

    }
}

