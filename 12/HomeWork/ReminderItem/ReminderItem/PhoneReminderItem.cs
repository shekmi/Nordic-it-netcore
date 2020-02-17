using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItem
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset dateTimeOffset, string alarmMessage, string phoneNumber) 
            : base(dateTimeOffset, alarmMessage)
        {
            phoneNumber = PhoneNumber;
        }

        public override void WriteProperties()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{GetType().Name}:\n" +
                $"AlarmDate: {AlarmDate}\n" +
                $"AlarmMessage: {AlarmMessage}\n" +
                $"TimeToAlarm: Days: {TimeToAlarm.Days}, Hours: {TimeToAlarm.Hours}, Minutes: {TimeToAlarm.Minutes}\n" +
                $"IsOutdated: {IsOutdated.ToString()}\n" +
                $"PhoneNumber: {PhoneNumber}");
            Console.ResetColor();
        }

    }
}
