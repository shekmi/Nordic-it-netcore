using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
    public class InMemoryReminderStorage : IReminderStorage
    {
        internal readonly Dictionary<Guid, ReminderItem> Storage;

        //public delegate void WhenAddingDone(object sender, EventArgs e);        
        //public WhenAddingDone RunWhenEventDone { get; set; }
        //или
        public EventHandler RunWhenAddingDone { get; set; } //делегат, который уже известен
        public event EventHandler OnAddSuccess; //cобытие

        public EventHandler RunWhenUpdatingDone { get; set; } //делегат, который уже известен
        public event EventHandler OnAddUpdateDone; //cобытие

        public InMemoryReminderStorage()
        {
            Storage = new Dictionary<Guid, ReminderItem>();
        }
        public void Add(ReminderItem reminderItem)
        {
            Storage.Add(reminderItem.Id, reminderItem);
            if(RunWhenAddingDone != null)
                RunWhenAddingDone(this, EventArgs.Empty);
                //или
            if (OnAddSuccess != null)
                OnAddSuccess(this, EventArgs.Empty);
        }
        public void Update(ReminderItem reminderItem)
        {
            Storage[reminderItem.Id] = reminderItem;
            RunWhenUpdatingDone(this, EventArgs.Empty);
        }

        public ReminderItem Get(Guid id)
        {
            return Storage.ContainsKey(id) ? Storage[id] : null;
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            //var result = new List<ReminderItem>();
            //foreach (var reminderItem in _storage.Values)
            //{
            //    if(reminderItem.Status == status)
            //    {
            //        result.Add(reminderItem);
            //    }
            //}
            //return result;
            //или

            return Storage
                .Values.Where(x => x.Status == status)
                .ToList();
        }

    }
}
