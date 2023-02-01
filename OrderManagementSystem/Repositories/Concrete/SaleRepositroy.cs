using ADO.NET_Helper;
using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Repositories.Concrete
{
    internal class SaleRepositroy : ISaleRepositroy
    {



        public SqlDataReader GetAllSales(out SqlConnection connection, string filter = "")
        {
            SqlHelper sqlHelper = new SqlHelper();
            SqlDataReader sqlDataReader = sqlHelper.ExecuteReader(query: " select *From vw_SaleTable", connection: out connection);
            return sqlDataReader;
        }

        public SqlDataReader GetProductsCombo(out SqlConnection connection, string filter = "")
        {

            SqlHelper sqlHelper = new SqlHelper();
            SqlDataReader sqlDataReader = sqlHelper.ExecuteReader(query: "select -1 as Id, N'Select' as Name union  select Id,Name from Products", connection: out connection);
            return sqlDataReader;

        }



        public Sale GetSaleById(int id)
        {
            Sale? sale = new Sale();
            SqlHelper sqlHelper = new();
            ConnectionManager connectionManager = new();
            SqlDataReader sqlDataReader = sqlHelper.ExecuteReader(query: $"select *from vw_SaleTableId where id={id}", connection: out SqlConnection connection);

            if (sqlDataReader.Read())
            {
                sale.Id = Convert.ToInt32(sqlDataReader["Id"]);
                sale.ProductPrice = Convert.ToDecimal(sqlDataReader["ProductPrice"]);
                sale.Remainder = Convert.ToInt32(sqlDataReader["Remainder"]);
                sale.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                sale.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                sale.SaleCount = Convert.ToInt32(sqlDataReader["SaleCount"]);

                connectionManager.CloseConnection(connection);
                return sale;
            }
            else
            {
                connectionManager.CloseConnection(connection);
                return null;
            }

        }

        public void DeleteSale(List<int> saleIds)
        {
            SqlHelper sqlHelper = new SqlHelper();
            string deletedIdList = string.Join(",", saleIds);

            sqlHelper.ExecuteNonQuery(query: $"Delete from Sales where Id in ({deletedIdList})");


        }

        public void Addsale(Sale sale)
        {
            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@UserId", sale.UserId),
                 new SqlParameter("@ProductId", sale.ProductId),
                 new SqlParameter("@SaleCount", sale.SaleCount)

            };
            sqlHelper.ExecuteNonQuery(query: "insert into Sales(UserId,ProductId,SaleCount) values (@UserId,@ProductId,@SaleCount); ", parameters: parameters);
        }
        public void EditSale(Sale sale)
        {

            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", sale.Id),
                new SqlParameter("@UserId", sale.UserId),
                new SqlParameter("@ProductId", sale.ProductId),
                new SqlParameter("@SaleCount", sale.SaleCount)
            };

            sqlHelper.ExecuteNonQuery(query: $"Update Sales set @UserId=UserId  ,@ProductId=ProductId , SaleCount=@SaleCount  where Id=@Id", parameters: parameters);
        }


    }
}
