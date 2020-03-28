using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IReminderStorage storage = new InMemoryReminderStorage();
            storage.Add(new ReminderItem(
                Guid.NewGuid(),
                "TelegramContactID",
                DateTimeOffset.Now,
                "Hello World ><"));

            List<ReminderItem> list = storage.Get(ReminderItemStatus.Awaiting);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
