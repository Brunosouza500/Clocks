using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Alarma
{
    public class Timehandler
    {

        // Attributes

        // Methods
        public Config.status_t setAlarm(Alarm alarm, DateTime alarmDate)
        {
            System.Threading.TimerCallback cb = new System.Threading.TimerCallback(alarm.trigger);

            System.Threading.Timer timer = new System.Threading.Timer(cb);

            DateTime now = DateTime.Now;
            DateTime dateAlarm = alarmDate;

            int msUntilAlarm = (int)(dateAlarm - now).TotalMilliseconds;

            timer.Change(msUntilAlarm, Timeout.Infinite);

            return Config.status_t.OK;
        }
    }
}
