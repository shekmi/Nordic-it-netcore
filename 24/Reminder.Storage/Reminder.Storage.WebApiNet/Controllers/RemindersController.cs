using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Storage.WebApiNet.Model;

namespace Reminder.Storage.WebApiNet.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    public class RemindersController : ControllerBase
    {
        private readonly ILogger<RemindersController> _logger;
        private readonly IReminderStorage _reminderStorage;

        public RemindersController(ILogger<RemindersController> logger,
            IReminderStorage reminderStorage)
        {
            _logger = logger;
            _reminderStorage = reminderStorage;
        }

        [HttpGet]
        public IActionResult GetReminders(
            [FromQuery(Name = "count")] int count = 0,
            [FromQuery(Name = "startPosition")] int startPosition = 0)
        {
            List<ReminderItem> reminderItems = _reminderStorage.Get(count, startPosition);
            List<ReminderItemGetModel> reminderItemGetModels =
                reminderItems
                .Select(x => new ReminderItemGetModel(x))
                .ToList();
            return Ok(reminderItemGetModels);
        }

        [HttpGet("{id}", Name = "GetReminderById")]
        public IActionResult GetReminder(Guid id)
        {
            var reminderItems = _reminderStorage.Get(id);
            if(reminderItems == null)
            {
                return NotFound();
            }
            return Ok(new ReminderItemGetModel(reminderItems));
        }
      
        [HttpPost]
        public IActionResult CreateReminder([FromBody] ReminderItemCreateModel reminderItemCreateModel)
        {
            if(reminderItemCreateModel == null) //400 ошибка
            {
                return BadRequest();
            }
            var reminderItem = reminderItemCreateModel.ToReminderItem();

            return CreatedAtAction(
                "GetReminderById",
                new { id = reminderItem.Id},
                reminderItem.)
        }
    }
}
