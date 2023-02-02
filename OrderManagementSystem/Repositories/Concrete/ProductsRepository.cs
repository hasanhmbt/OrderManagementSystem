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
    internal class ProductsRepository : IProductsRepository
    {

        public SqlDataReader GetAllProducts(out SqlConnection sqlConnection, string filter = "")
        {
            SqlHelper sqlHelper = new();

            SqlDataReader dataReader = sqlHelper.ExecuteReader(query: "select*from Products;", connection: out sqlConnection);

            return dataReader;
        }

        public Product GetProductById(int id)
        {
            Product product = new();
            SqlHelper sqlHelper = new();
            ConnectionManager connectionManager = new ConnectionManager();
            SqlDataReader dataReader = sqlHelper.ExecuteReader(query: $"select Name,Price,Quantity,AddDate from Products where id={id}", connection: out SqlConnection connection);

            if (dataReader.Read())
            {
                product.Name = Convert.ToString(dataReader["Name"]);
                product.Price = Convert.ToDecimal(dataReader["Price"]);
                product.Quantity = Convert.ToInt32(dataReader["Quantity"]);

                connectionManager.CloseConnection(connection);
                return product;
            }
            else
                connectionManager.CloseConnection(connection);
            return null;
        }

        public Product GetProductPrice(int id)
        {
            Product product = new();
            SqlHelper sqlHelper = new();
            ConnectionManager connectionManager = new ConnectionManager();
            SqlDataReader dataReader = sqlHelper.ExecuteReader(query: $"select  Price  from Products where id={id}", connection: out SqlConnection connection);

            if (dataReader.Read())
            {
                product.Price = Convert.ToDecimal(dataReader["Price"]);

                connectionManager.CloseConnection(connection);
                return product;
            }
            else
                connectionManager.CloseConnection(connection);
            return null;
        }





        public void AddProduct(Product product)
        {
            SqlHelper sqlHelper = new();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name",product.Name),
                new SqlParameter("@Price",product.Price),
                new SqlParameter("@Quantity",product.Quantity),

            };


            sqlHelper.ExecuteNonQuery(query: "insert into Products( Name, Price, Quantity) values (@Name,@Price,@Quantity);", parameters: parameters);

        }


        public void EditProduct(Product product)
        {
            SqlHelper sqlHelper = new();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id",product.Id),
                new SqlParameter("@Name",product.Name),
                new SqlParameter("@Price",product.Price),
                new SqlParameter("@Quantity",product.Quantity),

            };

            sqlHelper.ExecuteNonQuery(query: " update Products set Name=@Name,Price=@Price,Quantity=@Quantity where id=@Id;", parameters: parameters);

        }


        public void DeleteProduct(List<int> productIds)
        {
            SqlHelper sqlHelper = new();
            string deleteIds = string.Join(",", productIds);
            sqlHelper.ExecuteNonQuery(query: $"delete from Products where id={deleteIds}");
        }

    }
}
