using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItem
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }

        public string AccountName { get; set; }
        public ChatReminderItem(DateTimeOffset dateTimeOffset, string alarmMessage, string chatName, string accountName) : base(dateTimeOffset, alarmMessage)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{GetType().Name}:\n" +
                $"AlarmDate: {AlarmDate}\n" +
                $"AlarmMessage: {AlarmMessage}\n" +
                $"TimeToAlarm: Days: {TimeToAlarm.Days}, Hours: {TimeToAlarm.Hours}, Minutes: {TimeToAlarm.Minutes}\n" +
                $"IsOutdated: {IsOutdated.ToString()}\n" +
                $"ChatName: {ChatName}\n" +
                $"AccountName: {AccountName}\n");
            Console.ResetColor();
        }
    }
}
