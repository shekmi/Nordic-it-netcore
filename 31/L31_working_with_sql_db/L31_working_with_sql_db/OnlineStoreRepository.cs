using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace L31_working_with_sql_db
{
    public partial class OnlineStoreRepository
    {
        private string _connectionString;

        public OnlineStoreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            var resultConnection = new SqlConnection(_connectionString);
            resultConnection.Open();
            return resultConnection;
        }
    }
}
