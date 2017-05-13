using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using static Alarma.Config.status_t;

namespace Alarma
{
    public class Filehandler
    {

        // Attr.
        string alarmFilepath = Config.FILEPATH_ALARM;

        // Methods
        public Config.status_t storeAlarm(Alarm alarm)
        {

            Config.status_t st = ERROR_UKNOWN;

            try
            {

                List<string> alarmData = new List<string>();

                // Data dump: Year, Month, Day, Hour, Minute, Second, Melody
                alarmData = alarm.dumpDataAsList();

                if( (st = this.writeFile(this.alarmFilepath, alarmData, Config.FILE_FORMAT_CSV)) != OK)
                {
                    return st;
                }
            }
            catch (IOException IOEx)
            {
                throw IOEx;

            } catch (Exception Ex)
            {
                throw Ex;
            }

            return st;


        }

        Config.status_t writeFile(string filepath, List<string> data, string format)
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

            // Whatever goes wrong it will be an IOException, error handler should catch it
            return OK;

        }

        public List<Sound> getSoundList(string filepath)
        {
            // Create list to return
            List<Sound> retSoundList = new List<Sound>();

            // Get all sounds in sound directory
            string[] files = Directory.GetFiles(filepath, "*.mp3");

            string[] names = new string[files.Length];

            // Remove directory and extension
            for (int i = 0; i < files.Length; i++)
            {
                names[i] = Path.GetFileNameWithoutExtension(files[i]);
            }

            // Pass each sound name to the list
            foreach(var sound in names)
            {
                Sound song = new Sound(sound);
                retSoundList.Add(song);
            }

            // Return list
            return retSoundList;


        }

        // Constructor
        public Filehandler()
        {
            ///...
        }

    }
}
