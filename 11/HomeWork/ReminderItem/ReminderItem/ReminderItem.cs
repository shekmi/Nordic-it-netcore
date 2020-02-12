using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItem
{
    class ReminderItem
    {
        string _alarmMessage;
        public DateTimeOffset AlarmDate { get; set; }

        public string AlarmMessage 
        {
            get { return _alarmMessage; }
            set { _alarmMessage = value; }
        }

        public TimeSpan TimeToAlarm 
        {
            get { return DateTimeOffset.Now - AlarmDate; } 
        }

        public bool IsOutdated 
        {
            get { return TimeToAlarm >= TimeSpan.Zero ? true : false; }
        }

        ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public void WriteProperties()
        {
            Console.WriteLine($" AlarmDate: {AlarmDate}" +
                $"AlarmMessage: {AlarmMessage}" +
                $"TimeToAlarm: {TimeToAlarm}" +
                $"IsOutdated: {IsOutdated}");
        }
    }
}
