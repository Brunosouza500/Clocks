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

        public static string FILE_FORMAT_CSV = "csv";

        public static string FILE_STORE_ALARM_NAME = "alarmDB";



    }
}

