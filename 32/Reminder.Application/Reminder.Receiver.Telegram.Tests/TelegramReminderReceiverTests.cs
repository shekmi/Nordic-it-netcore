using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MihaZupan;

namespace Reminder.Receiver.Telegram.Tests
{
	[TestClass]
	public class TelegramReminderReceiverTests
	{
		//private const string _telegramBotAccessToken = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";
		//private const string _telegramBotProxyHost = "proxy.golyakov.net";
		//private const int _telegramBotProxyPort = 1080;
        private static TelegramReminderReceiver _telegramReminderReceiver;
        [ClassInitialize]
        public static void ClassInitialize()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(
                    "appsettings.json",
                    false,
                    true)
                .Build();
            IWebProxy proxy = null;
            bool useProxy = bool.Parse(config["telegramBot.UseProxy"]);
            if (useProxy)
            {
                string telegramBotProxyHost = config["telegramBot.Proxy.Host"];
                int telegramBotProxyPort = int.Parse(config["telegramBot.Proxy.Port"]);
                proxy = new HttpToSocks5Proxy(
                    telegramBotProxyHost,
                    telegramBotProxyPort);
            }
            _telegramReminderReceiver = new TelegramReminderReceiver(config, proxy);
        }
        [TestMethod]
		public void GetHelloFromBot_Returns_Not_Empty_String()
		{
			IWebProxy telegramProxy =
				new HttpToSocks5Proxy(_telegramBotProxyHost, _telegramBotProxyPort);
			var receiver = new TelegramReminderReceiver(_telegramBotAccessToken, telegramProxy);

			string description = receiver.GetHelloFromBot();

			Assert.IsNotNull(description);
		}
	}
}
