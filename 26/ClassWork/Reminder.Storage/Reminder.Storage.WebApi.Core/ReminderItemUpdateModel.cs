using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemUpdateModel
    {
		/// <summary>
		/// Gets or sets the identifier of the recipient.
		/// </summary>
		public ReminderItemStatus Status { get; set; }
	}
}
