using Reminder.Receiver.Core;
using System;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Reminder.Receiver.Telegram
{
    public class TelegramReminderReceiver : IReminderReceiver
    {
        private TelegramBotClient _botClient;

        public TelegramReminderReceiver(string token, IWebProxy proxy = null) //proxy можно опускать, как 2 параметр
        {
            _botClient = proxy == null
                ? new TelegramBotClient(token)
                : new TelegramBotClient(token, proxy);
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void Run() //подписаться на сообщение OnMessage
        {
            _botClient.OnMessage += BotClientOnOnMessage;
            _botClient.StartReceiving(); //начинаем слушать сообщения
        }

        private void BotClientOnOnMessage(object sender, MessageEventArgs e)
        {
            if(e.Message.Type == global::Telegram.Bot.Types.Enums.MessageType.Text)
            {
                OnMessageReceived(this,
                    new MessageReceivedEventArgs(
                        e.Message.Text,
                        e.Message.Chat.Id.ToString()));
            }
        }

        protected virtual void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(sender, e);
        }
    }
}
