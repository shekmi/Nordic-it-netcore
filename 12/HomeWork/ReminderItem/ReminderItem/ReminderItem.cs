using System;
using System.Text;

namespace ReminderItem
{
    public class ReminderItem
    {        
        public DateTimeOffset AlarmDate { get; set; }

        public string AlarmMessage { get; set; }
     
        public TimeSpan TimeToAlarm 
        {
            get
            {
                return (AlarmDate - DateTimeOffset.Now); 
            } 
        }

        public bool IsOutdated 
        {
            get { return TimeToAlarm >= TimeSpan.Zero ? true : false; }
        }

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public virtual void WriteProperties()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{GetType().Name}:\n" +
                $"AlarmDate: {AlarmDate}\n" +
                $"AlarmMessage: {AlarmMessage}\n" +
                $"TimeToAlarm: Days: {TimeToAlarm.Days}, Hours: {TimeToAlarm.Hours}, Minutes: {TimeToAlarm.Minutes}\n" +
                $"IsOutdated: {IsOutdated.ToString()}");
            Console.ResetColor();
        }
    }
}
