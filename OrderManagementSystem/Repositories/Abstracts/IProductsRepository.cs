using OrderManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Repositories.Abstracts
{
    internal interface IProductsRepository
    {

        public Product GetProductById(int id);
        public Product GetProductPrice(int id);

        public SqlDataReader GetAllProducts(out SqlConnection sqlConnection, string filter = "");

        public void AddProduct(Product product);
        public void EditProduct(Product product);

        public void DeleteProduct(List<int> productIds);


    }
}
