using System;
using System.Collections.Generic;
using System.Text;

namespace L31_working_with_sql_db
{
    interface IOrderRepository
    {
        int GetOrderCount();

        List<Tuple<int, string, DateTimeOffset, double>> GetOrderList();
    }
}
