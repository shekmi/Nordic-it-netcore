using System;
using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
    public class ReminderItemSendingFailedEventArgs : System.EventArgs
    {
        public ReminderItemStatusChangedModel Reminder { get; set; }

        public Exception Exception { get; set; }
        public ReminderItemSendingFailedEventArgs(
            ReminderItemStatusChangedModel reminder,
            Exception exception)
        {
            Reminder = reminder;
            Exception = exception;
        }
    }
}
