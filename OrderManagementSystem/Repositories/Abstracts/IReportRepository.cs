using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Repositories.Abstracts
{
    internal interface IReportRepository
    {

        SqlDataReader ProdctReports(out SqlConnection connection, string beginDate = "", string endDate = "");


    }
}
