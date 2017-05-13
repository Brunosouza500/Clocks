using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarma
{
    public static class Config
    {

        // Current forms
        public static List<string> FORMS = new List<string> { "Alarma", "Menu" };

        public static string FORM_ALARM = FORMS[0];
        public static string FORM_MENU = FORMS[1];

        public static string FILEPATH_ALARM = @"C:\Users\Usuario\Documents\CCPP\PROGRAMACION\ALARMA\";
        public static string FILEPATH_ALARM_SOUND = @"C:\Users\Usuario\Documents\CCPP\PROGRAMACION\ALARMA\";

        public static string FILE_FORMAT_CSV = "csv";

        public static string FILE_STORE_ALARM_NAME = "alarmDB";


        // Status ENUM
        // This enum willbe the status for displayError to handle errors.
        public enum status_t {
            OK = 1,

            ERROR_FILE = 100,
            ERROR_FILE_SOUNDPLAY,


            ERROR_TIME = 200,
            ERROR_TIME_ALARM_BEFORE_NOW = 201,


            ERROR_LOGIC = 300,
            ERROR_LOGIC_VALIDATE,


            ERROR_FRM = 400,
            ERROR_FRM_NOT_EXIST = 401,

            ERROR_UKNOWN = 0 /* "NULL" POINTER */
        }



    }
}

