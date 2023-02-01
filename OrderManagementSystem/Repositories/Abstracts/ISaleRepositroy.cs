using OrderManagementSystem.Entities;
using System.Data.SqlClient;

namespace OrderManagementSystem.Repositories.Abstracts
{
    internal interface ISaleRepositroy
    {
        public SqlDataReader GetAllSales(out SqlConnection connection, string filter = "");
        public SqlDataReader GetProductsCombo(out SqlConnection connection, string filter = "");

        public Sale GetSaleById(int id);

        public void DeleteSale(List<int> saleIds);

        public void Addsale(Sale sale);
        public void EditSale(Sale sale);
       

     
    }
}
