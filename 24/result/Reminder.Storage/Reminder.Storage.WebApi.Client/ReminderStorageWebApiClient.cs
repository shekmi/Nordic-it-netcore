using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Client
{
	public class ReminderStorageWebApiClient : IReminderStorage
	{
		private HttpClient _httpClient;


		public ReminderStorageWebApiClient()
		{
			_httpClient = new HttpClient();
		}

		public int Count => throw new NotImplementedException();

		public void Add(ReminderItem reminder)
		{
			// TODO
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public ReminderItem Get(Guid id)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
				HttpMethod.Get,
				"https://localhost:44344/api/reminders/" + id.ToString());

			var httpResponceMessage = _httpClient.SendAsync(httpRequestMessage).Result;

			if (httpResponceMessage.StatusCode == HttpStatusCode.NotFound)
			{
				return null;
			}

			if (httpResponceMessage.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception(
					$"Error: {httpResponceMessage.StatusCode}, " +
					$"Content: {httpResponceMessage.Content.ReadAsStringAsync().Result}");
			}

			string content = httpResponceMessage.Content.ReadAsStringAsync().Result;
			ReminderItemGetModel reminderItemGetModel = 
				JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

			return reminderItemGetModel.ToReminderItem();
		}

		public List<ReminderItem> Get(int count = 0, int startPostion = 0)
		{
			// TODO
		}

		public List<ReminderItem> Get(ReminderItemStatus status, int count = 0, int startPostion = 0)
		{
			throw new NotImplementedException();
		}

		public bool Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
			throw new NotImplementedException();
		}
	}
}
