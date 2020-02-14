using System;

namespace ReminderItem
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem reminderItem1 = new ReminderItem(DateTimeOffset.Parse("15/02/2020 09:00"), "Подъем_09:00");
            reminderItem1.WriteProperties();
            ReminderItem reminderItem2 = new ReminderItem(DateTimeOffset.Parse("14/02/2020 22:00"), "Подъем_22:00");
            reminderItem2.WriteProperties();
        }
    }
}
