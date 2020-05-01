using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MihaZupan;
using Newtonsoft.Json;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new HostBuilder()
				.ConfigureServices((hostContext, services) =>
				{
					services.AddSingleton<IConfiguration>(new ConfigurationBuilder().
				AddJsonFile(
				"appsettings.json",
				false,
				true)
				.Build());
				}).UseConsoleLifetime();

			IConfiguration config = new ConfigurationBuilder().
				AddJsonFile(
				"appsettings.json",
				false,
				true)
				.Build();

			var host = builder.Build();
			using (var servicesScope = host.Services.CreateScope())
			{
				var services = servicesScope.ServiceProvider;
				try
				{
					var config = services.GetService < IConfiguration>();
				}
				catch (Exception ex)
				{
					var logger services.GetRequiredService<ILogger<Program>>();
					logger.Lo
				}
			}

				/*var reminderItemRestricted = new ReminderItemRestricted
				{
					ContactId = "09090909",
					Date = DateTimeOffset.Now,
					Message = "Test Message",
					Status = ReminderItemStatus.Awaiting
				};
				Guid id = storage.Add(reminderItemRestricted);
				ReminderItem reminderItem = storage.Get(id);
				Console.WriteLine(
					JsonConvert.SerializeObject(reminderItem));

				storage.UpdateStatus(id, ReminderItemStatus.Failed);
				reminderItem = storage.Get(id);
				Console.WriteLine(
					JsonConvert.SerializeObject(reminderItem));
				*/

				var storage = new ReminderStorageWebApiClient(config["storageWebApiUrl"]);
			string telegramBotAccessToken = config["telegramBot.ApiToken"];
			//1230755607:AAG5-nrR-JUsUpr-5G2N
			bool useProxy = bool.Parse(config["telegramBot.UseProxy"]);
			string telegramBotProxyHost = config["telegramBot.Proxy.Host"];
			int telegramBotProxyPort = int.Parse(config["telegramBot.Proxy.Port"]);

			IWebProxy telegramProxy =
				new HttpToSocks5Proxy(telegramBotProxyHost, telegramBotProxyPort);

			var receiver = new TelegramReminderReceiver(
				telegramBotAccessToken, 
				useProxy ? telegramProxy : null);
			var sender = new TelegramReminderSender(
				telegramBotAccessToken,
				useProxy ? telegramProxy : null);

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
