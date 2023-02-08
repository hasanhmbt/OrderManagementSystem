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

        public int userId { get; set; }


        private void FrmProducts_Load(object sender, EventArgs e)
        {
            RefreshProductTable();

        }

        public void RefreshProductTable()
        {
            IProductsRepository productsRepository = new ProductsRepository();
            ControlFiller controlFiller = new ControlFiller();
            SqlDataReader sqlDataReader = productsRepository.GetAllProducts(out SqlConnection sqlConnection);

            controlFiller.FillControlDataSource(tblProducts, sqlDataReader);
            tblProducts.ClearSelection();
            sqlConnection.Close();
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                FrmSaveProduct frmSaveProduct = new();
                frmSaveProduct.ProductId = -1;
                frmSaveProduct.ProductForm = this;
                frmSaveProduct.Show();
            }
            catch (Exception ex)
            {
                CommonTools.LogException(ex, this.userId);
                MessageBox.Show($"{ex}", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {


                FrmSaveProduct frmSaveProduct = new();
                if (tblProducts.SelectedRows.Count == 0)
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
            catch (Exception ex)
            {
                CommonTools.LogException(ex, this.userId);
                MessageBox.Show($"{ex}", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult result = MessageBox.Show("Are you sure to delete?", caption: "Attention", icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    if (tblProducts.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Select a product!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                        return;
                    }
                    List<int> selectedIds = new List<int>();

                    foreach (DataGridViewRow row in tblProducts.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        selectedIds.Add(id);
                    }
                    MessageBox.Show("Succesfully deleted!");

                    IProductsRepository productsRepository = new ProductsRepository();
                    productsRepository.DeleteProduct(selectedIds);
                    RefreshProductTable();
                }
            }
            catch (Exception ex)
            {
                CommonTools.LogException(ex, this.userId);
                MessageBox.Show($"{ex}", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);

            }
        }


    }
}
