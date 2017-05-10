using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Alarma
{
    public class Filehandler
    {

        // Attr.
        string alarmFilepath = Config.FILEPATH_ALARM;

        // Methods
        public void storeAlarm(Alarm alarm)
        {

            try
            {

                List<string> alarmData = new List<string>();

                // Data dump: Year, Month, Day, Hour, Minute, Second, Melody
                alarmData = alarm.dumpDataAsList();

                this.writeFile(this.alarmFilepath, alarmData, Config.FILE_FORMAT_CSV);
            }
            catch (IOException IOEx)
            {
                throw IOEx;

            } catch (Exception Ex)
            {
                throw Ex;
            }


        }

        void writeFile(string filepath, List<string> data, string format)
        {
            if (format == Config.FILE_FORMAT_CSV)
            {
                string csvFile = this.alarmFilepath + Config.FILE_STORE_ALARM_NAME + "." + Config.FILE_FORMAT_CSV;
                // Create a stream writer
                using (StreamWriter sw = new StreamWriter(csvFile, append: true))
                {

                    int i = 0;
                    foreach (var _data in data)
                    {

                        if (i == data.Count - 1) { sw.Write(_data + Environment.NewLine); break; }

                        sw.Write(_data + ", ");
                        i++;
                    }
                }
            } else
            {
                // Some other format...
            }

        }

        // Constructor
        public Filehandler()
        {
            ///...
        }

    }
}
