using System;
using System.Collections.Generic;

namespace ReminderItem
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Parse("15/02/2020 09:00"), "Подъем_09:00");
            PhoneReminderItem phoneReminderItem = new PhoneReminderItem(DateTimeOffset.Parse("03/03/2020 09:00"), "Звонок_12:00", "+7(962)900-99-64");
            ChatReminderItem chatReminderItem = new ChatReminderItem(DateTimeOffset.Parse("14/02/2020 22:00"), "Подъем_22:00", "Favorite hobby", "Anastasia");
            List<ReminderItem> listReminderItem = new List<ReminderItem>
            {
                reminderItem,
                phoneReminderItem,
                chatReminderItem
            };

            foreach (var item in listReminderItem)
            {
                item.WriteProperties();
            }
        }
    }
}
