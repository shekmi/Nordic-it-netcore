using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;
using System.Threading;
using Reminder.Domain.EventArgs;
using Reminder.Domain.Model;

namespace Reminder.Domain
{
    public class ReminderDomain
    {
        private IReminderStorage _storage;
        private Timer _awaitingRemindersCheckTimer; //Проверяет все awaiting не пора ли сделать их ready

        public event EventHandler<ReminderItemStatusChangedEventArgs> ReminderItemReady;
        public ReminderDomain(IReminderStorage storage)
        {
            _storage = storage;
        }

        public void Run() //запускать таймер
        {
            _awaitingRemindersCheckTimer = new Timer(
                CheckAwaitingReminders,
                null,
                TimeSpan.Zero, //запускаем сразу
                TimeSpan.FromSeconds(2)); //насколько часто проверять
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
                
                //cобытие
                ReminderItemReady?.Invoke(
                    this,
                    new ReminderItemStatusChangedEventArgs(
                        new ReminderItemStatusChangedModel(
                            item,
                            previousStatus)));
            }
        }

    }
}
