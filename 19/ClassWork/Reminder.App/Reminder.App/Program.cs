using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Domain.Model;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IReminderStorage storage = new InMemoryReminderStorage();
            ReminderDomain domain = new ReminderDomain(storage);
            domain.ReminderItemReady += OnReminderItemReady;

            storage.Add(new ReminderItem(
                Guid.NewGuid(),
                "TelegramContactID",
                DateTimeOffset.Now,
                "Hello World ><"));

            domain.Run();

            //List<ReminderItem> list = storage.Get(ReminderItemStatus.Awaiting);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void OnReminderItemReady(object sender, ReminderItemStatusChangedEventArgs e)
        {
            Console.WriteLine(
                $"Reminder of contact {e.Reminder.ContactId}" +
                $" has change status from {e.Reminder.PreviousStatus}" +
                $" to {e.Reminder.Status}!!!");
        }
    }
}
