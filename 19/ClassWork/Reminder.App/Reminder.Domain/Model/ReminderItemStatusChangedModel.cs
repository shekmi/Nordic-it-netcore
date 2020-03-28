using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage.Core;

namespace Reminder.Domain.Model
{
    public class ReminderItemStatusChangedModel
    {
        public string ContactId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }       
        public ReminderItemStatus Status { get; set; }
        public ReminderItemStatus PreviousStatus { get; set; }
        public ReminderItemStatusChangedModel()
        {

        }
        public ReminderItemStatusChangedModel(ReminderItem reminderItem, ReminderItemStatus previousStatus)
        {
            ContactId = reminderItem.ContactId;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            Status = reminderItem.Status;
            PreviousStatus = previousStatus;
        }
    }
}
