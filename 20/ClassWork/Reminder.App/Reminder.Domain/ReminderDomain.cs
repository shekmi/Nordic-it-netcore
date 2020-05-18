using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;
using System.Threading;
using Reminder.Domain.EventArgs;
using Reminder.Domain.Model;
using Reminder.Receiver.Core;
using Reminder.Parsing;
using Reminder.Sender.Core;

namespace Reminder.Domain
{
    public class ReminderDomain
    {
        private IReminderStorage _storage;
        private IReminderReceiver _receiver;
        private IReminderSender _sender;

        private Timer _awaitingRemindersCheckTimer; //Проверяет все awaiting не пора ли сделать их ready
        private Timer _readyReminderSetTimer;

        public event EventHandler<ReminderItemStatusChangedEventArgs> ReminderItemReady;
        public event EventHandler<ReminderItemSendingFailedEventArgs> ReminderItemSendingFailed;
        public ReminderDomain(IReminderStorage storage, IReminderReceiver receiver, IReminderSender sender)
        {
            _storage = storage;
            _receiver = receiver;
            _sender = sender;
            _receiver.MessageReceived += ReceiverOnMessageReceived;
        }

        public void Run()
        {
            _awaitingRemindersCheckTimer = new Timer(
                CheckAwaitingReminders,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(2));

            _readyReminderSetTimer = new Timer(
                SendReadyReminders,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            
            _receiver.Run(); //чтобы слушать новые сообщения (добавлять новые сообщения сторедж)
        }        

        private void CheckAwaitingReminders(object dummy) //то что не будет использоваться, отмечается "dummy"
        {
            //Read items in status Awaiting
            //Check and if IsTimeToSend
            //then update status to ReadyToSend

            var items = _storage
                .Get(ReminderItemStatus.Awaiting)
                .Where(
                x => x.IsTimeToSend());
            foreach (var item in items)
            {
                var previousStatus = item.Status;
                item.Status = ReminderItemStatus.ReadyToSend;
                _storage.Update(item);
                //if (OnReminderItemReady != null)
                   // OnReminderItemReady(this, EventArgs.Empty);
                ReminderItemReady?.Invoke(
                    this,
                    new ReminderItemStatusChangedEventArgs(
                        new ReminderItemStatusChangedModel(
                            item,
                            previousStatus)));
            }
        }
        private void SendReadyReminders(object state)
        {
            var items = _storage
               .Get(ReminderItemStatus.ReadyToSend);

            foreach (var item in items)
            {
                var previousStatus = item.Status;
                try
                {
                    _sender.Send(item.ContactId, item.Message); //посылка сообщения

                    item.Status = ReminderItemStatus.SuccessfullySent;
                    _storage.Update(item);

                    ReminderItemReady?.Invoke(
                    this,
                    new ReminderItemStatusChangedEventArgs(
                    new ReminderItemStatusChangedModel(
                    item,
                    previousStatus)));
                }
                catch (Exception e)
                {
                    item.Status = ReminderItemStatus.Failed;
                    ReminderItemSendingFailed?.Invoke(
                   this,
                   new ReminderItemSendingFailedEventArgs(
                   new ReminderItemStatusChangedModel(
                   item,
                   previousStatus), e));
                }

            }
        }

        private void ReceiverOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            //parsing of the e.Message to get alarm message and date
            var parsedMessage = MessageParser.ParseMessage(e.Message);

            if(parsedMessage == null)
            {
                // we can raise some MessageParsingFailed event
                //сделать event
                return;
            }

            var item = new ReminderItem(
                Guid.NewGuid(),
                e.ContactId,
                parsedMessage.Date,
                parsedMessage.Message);

            //adding new reminder item to the storage
            _storage.Add(item);

            //send message that reminder item was added
        }
    }
}
