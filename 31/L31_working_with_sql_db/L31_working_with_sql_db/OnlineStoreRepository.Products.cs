using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace L31_working_with_sql_db
{
    public partial class OnlineStoreRepository : IProductRepository
    {
        public int GetProductCount()
        {
            using var connection = GetOpenedSqlConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) FROM [dbo].[Product]";
            return (int)command.ExecuteScalar();
        }

        public List<Tuple<int, string>> GetProductList()
        {
            var result = new List<Tuple<int, string>>();
            using var connection = GetOpenedSqlConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT [Id], [Name] FROM [dbo].[Product]";
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return result;
            }
            int ordinalOfId = reader.GetOrdinal("Id");
            int ordinalOfName = reader.GetOrdinal("Name");
            while (reader.Read())
            {
                int id = reader.GetInt32(ordinalOfId);
                string name = reader.GetString(ordinalOfName);
                var record = new Tuple<int, string>(id, name);
                result.Add(record);
            }
            return result;
        }
    }
}
