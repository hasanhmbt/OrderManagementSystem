using ADO.NET_Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Repositories.Abstracts;

namespace OrderManagementSystem.Repositories.Concrete
{
    internal class ReportRepository : IReportRepository
    {

        public SqlDataReader ProdctReports(out SqlConnection connection, string beginDate = "", string endDate = "")
        {
            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
              new SqlParameter("@Firstdate",beginDate),
              new SqlParameter("@Lastdate",endDate)

            };

            SqlDataReader reader = sqlHelper.ExecuteReader(query: "SP_RPT_ProductCount", commandType: CommandType.StoredProcedure, connection: out connection, parameters: parameters);

            return reader;
        }

    }
}
