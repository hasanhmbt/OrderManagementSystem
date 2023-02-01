using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            RefreshProductTable();

        }

        public void RefreshProductTable()
        {
            IProductsRepository productsRepository = new ProductsRepository();
            ControlFiller controlFiller = new ControlFiller();
            SqlDataReader sqlDataReader = productsRepository.GetAllProducts(out SqlConnection sqlConnection);

            controlFiller.FillControlDataSource(tblProducts, sqlDataReader );
            tblProducts.ClearSelection();
            sqlConnection.Close();
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSaveProduct frmSaveProduct = new();
            frmSaveProduct.ProductId = -1;
            frmSaveProduct.ProductForm = this;
            frmSaveProduct.Show();
              
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            FrmSaveProduct frmSaveProduct = new();
            if (tblProducts.SelectedRows.Count==0)
            {
                MessageBox.Show("Select a product!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return;
            }
            else
            {
                frmSaveProduct.ProductId = (int)tblProducts.SelectedRows[0].Cells["Id"].Value;
                frmSaveProduct.ProductForm = this;
                frmSaveProduct.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tblProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return;
            }
            List<int> selectedIds= new List<int>();

            foreach (DataGridViewRow row in tblProducts.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                selectedIds.Add(id);
            }

            IProductsRepository productsRepository = new ProductsRepository();
            productsRepository.DeleteProduct(selectedIds);
            RefreshProductTable();
        }

        
    }
}
