﻿using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;
using System.Data.SqlClient;

namespace OrderManagementSystem
{
    public partial class FrmSaveSales : Form
    {
        public FrmSaveSales()
        {
            InitializeComponent();
        }

        public int salesId { get; set; } = -1;
        public int userId { get; set; }
        public FrmSales saleData { get; set; }



        private void SaveSales_Load(object sender, EventArgs e)
        {
            FillProductsCombo();

            if (salesId == -1)
            {
                this.Text = "Add Sale";
            }
            else
            {
                this.Text = "Edit Sale";
                ISaleRepositroy saleRepositroy = new SaleRepositroy();
                Sale sale = saleRepositroy.GetSaleById(salesId);


                if (sale != null)
                {


                    labelTotal.Text = sale.TotalPrice.ToString();
                    labelPrice.Text = sale.ProductPrice.ToString();
                    cmbProducts.SelectedValue = sale.ProductId;
                    numCount.Value = sale.SaleCount;

                }

            }
        }

        public void FillProductsCombo()
        {
            ControlFiller controlFiller = new ControlFiller();
            ISaleRepositroy saleRepositroy = new SaleRepositroy();
            SqlDataReader sqlDataReader = saleRepositroy.GetProductsCombo(out SqlConnection sqlConnection);

            controlFiller.FillControlDataSource(cmbProducts, sqlDataReader, valueMember: "Id", displayMember: "Name");

            sqlConnection.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(labelRemainder.Text) > Convert.ToInt32(numCount.Value))
                {
                    ISaleRepositroy saleRepositroy = new SaleRepositroy();
                    if (salesId == -1)
                    {
                        saleRepositroy.Addsale(new Sale { UserId = this.userId, ProductId = (int)cmbProducts.SelectedValue, TotalPrice = Convert.ToDecimal(labelTotal.Text), SaleCount = Convert.ToInt32(numCount.Value) });
                    }
                    else
                    {
                        saleRepositroy.EditSale(new Sale { Id = salesId, UserId = this.userId, TotalPrice = Convert.ToDecimal(labelTotal.Text), ProductId = (int)cmbProducts.SelectedValue, SaleCount = Convert.ToInt32(numCount.Value) });
                    }
                    saleData.RefreshSalesTable();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter a valid number!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                CommonTools.LogException(ex, this.userId);
                MessageBox.Show($"{ex}", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);

            }

        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbProducts.SelectedIndex != 0)
            {
                IProductsRepository productsRepository = new ProductsRepository();
                ProductModel productprice = productsRepository.GetProductPrice(Convert.ToInt32(cmbProducts.SelectedValue));
                labelPrice.Text = productprice.Price.ToString();
                labelRemainder.Text = productprice.Remainder.ToString();

                decimal total = productprice.Price * numCount.Value;
                labelTotal.Text = total.ToString();
            }

        }



        private void numCount_ValueChanged(object sender, EventArgs e)
        {

            if (cmbProducts.SelectedIndex != 0)
            {
                IProductsRepository productsRepository = new ProductsRepository();
                ProductModel productprice = productsRepository.GetProductPrice(Convert.ToInt32(cmbProducts.SelectedValue));
                decimal total = productprice.Price * numCount.Value;
                labelTotal.Text = total.ToString();

            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
