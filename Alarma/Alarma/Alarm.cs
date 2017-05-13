using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Windows.Forms;
using System.Media;

namespace Alarma
{
    public class Alarm
    {
        // Attr
        public int hora { get; set; }
        public int minuto { get; set; }
        public int segundo { get; set; }

        public int dia { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }

        public string melodia { get; set; }

        // Methods
        public List<string> dumpDataAsList()
        {
            List<string> retList = new List<string> { this.anio.ToString(), this.mes.ToString(), this.dia.ToString(), this.hora.ToString(), this.minuto.ToString(), this.segundo.ToString(), this.melodia };

            return retList;
        }

        public void trigger(object obj)
        {
            MessageBox.Show("Timer works:DDD");

            // Sound alarm
            string soundString = Config.FILEPATH_ALARM_SOUND + this.melodia + ".mp3";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundString);
            try
            {
                player.Play();
            }
            catch (Exception)
            {

                Logic LogicClass = new Logic();
                LogicClass.displayError(Config.status_t.ERROR_FILE_SOUNDPLAY);
            }



            // Delete alarm from .csv file
            // DIspose timer           

        }

        // Constructor
        public Alarm(int hora, int minuto, int segundo, int dia, int mes, int anio, string melodia)
        {
            // Constructor

            this.hora = hora;
            this.minuto = minuto;
            this.segundo = segundo;

            this.dia = dia;
            this.mes = mes;
            this.anio = anio;

            this.melodia = melodia;
        }

        public Alarm()
        {
            //...
        }



    }
}
