using System;
using System.Data;
using System.Data.SqlClient;

namespace L31_working_with_sql_db
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new OnlineStoreRepository(
     @"Data Source=DESKTOP-N07GO5O\SQLEXPRESS;Initial Catalog=OnlineStore;Integrated Security=True");
            var records = repo.GetProductList();
            foreach (var record in records)
            {
                Console.WriteLine($"Product ID = {record.Item1}, Name = \"{record.Item2}\"");
            }
            Console.WriteLine($"Total number of products = {repo.GetProductCount()}");

         
                var orders = repo.GetOrderList();
                foreach (var order in orders)
                {
                    Console.Write($"Order ID = {order.Item1}, " +
                                  $"Customer Name = \"{order.Item2}\", " +
                                  $"Date = {order.Item3:d}");
                    if (order.Item4.HasValue)
                        Console.Write($", Discount = {order.Item4.Value * 100}%");
                    Console.WriteLine();
                }
                Console.WriteLine($"Total number of orders = {repo.GetOrderCount()}");
            


            //            using SqlConnection sqlConnection = new SqlConnection(
            //                @"Data Source = DESKTOP-N07GO5O\SQLEXPRESS;
            //                Initial Catalog=OnlineStore;
            //                Integrated Security=true;");
            //            sqlConnection.Open();
            //            var sqlCommand = sqlConnection.CreateCommand();
            //            sqlCommand.CommandType = CommandType.Text;
            //            sqlCommand.CommandText = "SELECT COUNT(*) FROM [dbo].[Customer]";
            //            int numberOfCustomers = (int)sqlCommand.ExecuteScalar();

            //            Console.WriteLine(numberOfCustomers);

            //            sqlCommand.CommandText = @"
            //-- Найти ID и имена клиентов, сделавших заказы в 2018 году
            //SELECT C.[Id], C.[Name]
            //FROM [dbo].[Customer] AS C
            //WHERE C.[Id] IN (
            //	SELECT O.CustomerId
            //	FROM [dbo].[Order] AS O
            //	WHERE YEAR(O.OrderDate) = 2018
            //)";
            //            using SqlDataReader reader= sqlCommand.ExecuteReader();

            //            if(reader.HasRows)
            //            {
            //                int ordinalOfId = reader.GetOrdinal("Id");
            //                int ordinalOfName = reader.GetOrdinal("Name");

            //                while (reader.Read())
            //                {
            //                    int customerId = reader.GetInt32(ordinalOfId);
            //                    string customerName = reader.GetString(ordinalOfName);
            //                    Console.WriteLine($"Customer Id = {customerId}, Name = {customerName}");
            //                }
            //            }

        }
    }
}
