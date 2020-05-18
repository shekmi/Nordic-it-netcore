﻿using System;
using System.Net;
using Reminder.Sender.Core;
using Telegram.Bot;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        private TelegramBotClient _botClient;

        public TelegramReminderSender(string token, IWebProxy proxy = null) //proxy можно опускать, как 2 параметр
        {
            _botClient = proxy == null
                ? new TelegramBotClient(token)
                : new TelegramBotClient(token, proxy);
        }

        public void Send(string contactId, string message)
        {
            var chatId = new global::Telegram.Bot.Types.ChatId(
                long.Parse(contactId));

            _botClient.SendTextMessageAsync(chatId, message);          
        }
    }
}
