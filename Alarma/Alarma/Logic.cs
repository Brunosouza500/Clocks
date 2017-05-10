using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarma
{
    public class Logic
    {

        public bool validateArguments(string form, string hour, string minute, string second, DateTime alarmDate, out string errorMessage, out DateTime retAlarmDate)
        {
            int count;
            errorMessage = "";

            if (!this.formExists(form, out count))
            {
                errorMessage = "Form does not exist.";
                retAlarmDate = DateTime.Now;
                return false;
            }

            if (!this.validate(Config.FORMS[count], hour, minute, second, alarmDate, out retAlarmDate))
            {
                errorMessage = "Invalid Alarm";
                return false;
            }

            return true;

        }

        bool validate(string form, string hour, string minute, string second, DateTime alarmDate, out DateTime retAlarmDate)
        {
            if (form == Config.FORM_ALARM)
            {
                // "mon/day/year hour:min:sec"
                string dateString = alarmDate.Day + "/" + alarmDate.Month + "/" + alarmDate.Year + " " + hour + ":" + minute + ":" + second;
                MessageBox.Show(dateString);
                DateTime dateValue = new DateTime();

                if ((DateTime.TryParse(dateString, out dateValue)) && (!hasEmptyString(hour, minute, second)))
                {
                    // dateValue may be good for some other method somewhere else.
                    retAlarmDate = dateValue;
                    return true;
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

            return false;
        }

        bool formExists(string form, out int count)
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
                return false;
            }

            return true;
        }

        bool hasEmptyString(params string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == String.Empty) { return true; }
            }

            return false;
        }

        public void storeAlarm(Alarm alarm)
        {
            // Create file handler, Logic has no storeAlarm method because it is not pertinent.
            Filehandler fileH = new Filehandler();

            // Call fileHandler to handle storage in files.
            try
            {
                fileH.storeAlarm(alarm);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

    }


}

