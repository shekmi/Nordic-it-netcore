﻿using System;
using System.Net;
using MihaZupan;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.InMemory;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			var storage = new InMemoryReminderStorage();

			const string telegramBotAccessToken = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";
			const string telegramBotProxyHost = "proxy.golyakov.net";
			const int telegramBotProxyPort = 1080;

			IWebProxy telegramProxy =
				new HttpToSocks5Proxy(telegramBotProxyHost, telegramBotProxyPort);

			var receiver = new TelegramReminderReceiver(telegramBotAccessToken, telegramProxy);
			var sender = new TelegramReminderSender(telegramBotAccessToken, telegramProxy);

			var domain = new ReminderDomain(storage, receiver, sender);

			domain.AddingSucceeded += Domain_AddingSucceeded;
			domain.SendingSucceeded += Domain_SendingSucceeded;
			domain.SendingFailed += Domain_SendingFailed;

			domain.Run();

			Console.WriteLine(
				"Reminder application is running...\n" +
				"Press [Enter] to shutdown.");
			Console.ReadLine();
		}

		private static void Domain_AddingSucceeded(
			object sender,
			AddingSuccededEventArgs e)
		{
			Console.WriteLine(
				$"Reminder from contact ID {e.Reminder.ContactId} " +
				$"with the message \"{e.Reminder.Message}\" " +
				$"successfully scheduled on {e.Reminder.Date:s}");
		}

		private static void Domain_SendingSucceeded(
			object sender,
			SendingSuccededEventArgs e)
		{
			Console.WriteLine(
				"Reminder {0:N} successfully sent message text \"{1}\"",
				e.Reminder.Id,
				e.Reminder.Message);
		}

		private static void Domain_SendingFailed(object sender, SendingFailedEventArgs e)
		{
			Console.WriteLine(
				"Reminder {0:N} sending has failed. Exception:\n{1}",
				e.Reminder.Id,
				e.Exception);
		}

	}
}
