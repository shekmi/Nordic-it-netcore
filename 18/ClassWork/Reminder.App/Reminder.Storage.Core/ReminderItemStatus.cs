using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
    public enum ReminderItemStatus
    {
        Awaiting,
        ReadyToSend,
        SuccessfullySent,
        Failed
    }
}
