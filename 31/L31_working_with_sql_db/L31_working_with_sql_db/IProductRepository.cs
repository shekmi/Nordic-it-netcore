using System;
using System.Collections.Generic;
using System.Text;

namespace L31_working_with_sql_db
{
    interface IProductRepository
    {
        int GetProductCount();
        List<Tuple<int, string>> GetProductList();
    }
}
