using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Reminder.Storage.Core;

namespace Reminder.Storage.SqlServer.ADO
{
    public class SqlServerReminderStorage : IReminderStorage
    {
        #region MyRegion
        public int Count => throw new NotImplementedException();
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion

        private string _connection;

        public Guid Add(ReminderItemRestricted reminder)
        {
            throw new NotImplementedException();
        }

        public ReminderItem Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ReminderItem> Get(int count = -1, int startPosition = 0)
        {
            throw new NotImplementedException();
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count = 0, int startPosition = 0)
        {
            throw new NotImplementedException();
        }


        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            foreach (var id in ids)
            {
                UpdateStatus(id, status);
            }
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            var resultConnection = new SqlConnection(_connection);
            resultConnection.Open();
            return resultConnection;
        }
    }
}
