using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class FrmSaveProduct : Form
    {
        public FrmSaveProduct()
        {
            InitializeComponent();
        }
        public int ProductId { get; set; }
        public int userId { get; set; }

        public FrmProducts ProductForm { get; set; }
        private void FrmSaveProduct_Load(object sender, EventArgs e)
        {

            if (ProductId == -1)
            {
                this.Text = "Add Product";
            }
            else
            {
                this.Text = "Edit Product";
                IProductsRepository productsRepository = new ProductsRepository();
                Product product = productsRepository.GetProductById(ProductId);

                if (product != null)
                {
                    txtProduct.Text = product.Name;
                    numPrice.Value = product.Price;
                    numQuantity.Value = product.Quantity;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                IProductsRepository productsRepository = new ProductsRepository();
                if (ProductId == -1)
                {
                    productsRepository.AddProduct(new Product { Name = txtProduct.Text, Price = (decimal)numPrice.Value, Quantity = (int)numQuantity.Value });
                }
                else
                {
                    productsRepository.EditProduct(new Product { Id = ProductId, Name = txtProduct.Text, Price = (decimal)numPrice.Value, Quantity = (int)numQuantity.Value });
                }

                ProductForm.RefreshProductTable();
                this.Close();
            }
            catch (Exception ex)
            {
                CommonTools.LogException(ex, this.userId);
                MessageBox.Show($"{ex}", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);

            }

        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
