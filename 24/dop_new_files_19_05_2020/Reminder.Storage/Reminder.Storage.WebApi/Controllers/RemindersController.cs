using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Controllers
{
	[ApiController]
	[Route("api/reminders")]
	public class RemindersController : ControllerBase
	{
		private readonly ILogger<RemindersController> _logger;
		private readonly IReminderStorage _reminderStorage;

		public RemindersController(
			ILogger<RemindersController> logger,
			IReminderStorage reminderStorage)
		{
			_logger = logger;
			_reminderStorage = reminderStorage;
		}

		[HttpGet]
		public IActionResult GetReminders(
			[FromQuery(Name = "count")] int count = 0, 
			[FromQuery(Name = "startPostion")] int startPostion = 0)
		{
			List<ReminderItem> reminderItems = _reminderStorage.Get(count, startPostion);
			List<ReminderItemGetModel> reminderItemGetModels =
				reminderItems
					.Select(x => new ReminderItemGetModel(x))
					.ToList();

			return Ok(reminderItemGetModels);
		}

		[HttpGet("{id}")]
		public IActionResult GetReminder(Guid id)
		{
			var reminderItem = _reminderStorage.Get(id);
			if (reminderItem == null)
			{
				return NotFound();
			}

			return Ok(new ReminderItemGetModel(reminderItem));
		}

		[HttpPost]
		public IActionResult CreateReminder([FromBody] ReminderItemCreateModel reminderItemCreateModel)
		{
			if (reminderItemCreateModel == null)
			{
				return BadRequest();
			}

			var reminderItem = reminderItemCreateModel.ToReminderItem(Guid.NewGuid());
			_reminderStorage.Add(reminderItem);

			var reminderItemGetModel = new ReminderItemGetModel(reminderItem);

			return CreatedAtAction(
				"GetReminder",
				new {id = reminderItem.Id},
				reminderItemGetModel);
		}
	}
}