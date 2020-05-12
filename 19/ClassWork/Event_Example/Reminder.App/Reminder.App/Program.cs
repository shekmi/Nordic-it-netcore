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

            ((InMemoryReminderStorage)storage).RunWhenAddingDone = (sender, e) =>
            {
                Console.WriteLine("DELEGATE New item added!");
            };
            //Или
            ((InMemoryReminderStorage)storage).OnAddSuccess += (sender, e) =>
            {
                Console.WriteLine("EVENT New Item Added");
            };

            ((InMemoryReminderStorage)storage).RunWhenUpdatingDone = (sender, e) =>
            {
                Console.WriteLine("Item Update");
            };

            ReminderItem item = new ReminderItem(
                Guid.NewGuid(),
                "TelegramContactID",
                DateTimeOffset.Now,
                "Hello World ><");
            storage.Add(item);
            item.Message = "UPDATE MESSAGE!!!";
            storage.Update(item);

            List<ReminderItem> list = storage.Get(ReminderItemStatus.Awaiting);
            foreach (var listItem in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
