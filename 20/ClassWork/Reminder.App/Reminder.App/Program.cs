using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Domain.Model;
using Reminder.Receiver.Core;
using Reminder.Receiver.Telegram;
using System.Net;
using MihaZupan;
using Reminder.Sender.Core;
using Reminder.Sender.Telegram;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            const string token = "1230755607:AAG5-nrR-JUsUpr-5G2NEeoNfdjbEZPXqQM";
            const string proxyHost = "proxy.litvinova.net"; //"proxy.golyakov.net";
            const int proxyPort = 1080;
            IWebProxy proxy = new HttpToSocks5Proxy(proxyHost, proxyPort);

            IReminderStorage storage = new InMemoryReminderStorage();
            IReminderReceiver recevier = new TelegramReminderReceiver(token/*,proxy*/);
            IReminderSender sender = new TelegramReminderSender(token);

            ReminderDomain domain = new ReminderDomain(storage, recevier, sender);
            domain.ReminderItemReady += OnReminderItemReady;

            //storage.Add(new ReminderItem(
            //    Guid.NewGuid(),
            //    "TelegramContactID",
            //    DateTimeOffset.Now,
            //    "Hello World ><"));

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
