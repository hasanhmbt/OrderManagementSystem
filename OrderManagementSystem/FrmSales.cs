using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;
using System.Data.SqlClient;

namespace OrderManagementSystem
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        public int saleId { get; set; } = -1;
        public Product productData { get; set; }
        public int userId { get; set; }

        private void FrmSales_Load(object sender, EventArgs e)
        {

            RefreshSalesTable();

        }


        public void RefreshSalesTable()
        {
            ControlFiller controlFiller = new ControlFiller();
            ISaleRepositroy saleRepositroy = new SaleRepositroy();
            SqlDataReader sqlDataReader = saleRepositroy.GetAllSales(out SqlConnection sqlConnection);

            controlFiller.FillControlDataSource(tblSales, sqlDataReader);
            tblSales.ClearSelection();
            sqlConnection.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                FrmSaveSales saveSales = new();
                saveSales.salesId = -1;
                saveSales.userId = this.userId;
                saveSales.saleData = this;
                saveSales.Show();

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

                FrmSaveSales saveSales = new();
                if (tblSales.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a sale!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    saveSales.salesId = (int)tblSales.SelectedRows[0].Cells["Id"].Value;
                    saveSales.saleData = this;
                    saveSales.Show();
                }

            }
            catch (Exception ex)
            {
                CommonTools.LogException(ex, this.userId);
                MessageBox.Show($"{ex}", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);

            }
        }

        private void brnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult result = MessageBox.Show("Are you sure to delete?", caption: "Attention", icon: MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    if (tblSales.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Select a item!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                        return;
                    }
                    List<int> selectedIds = new List<int>();

                    foreach (DataGridViewRow row in tblSales.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        selectedIds.Add(id);
                    }
                    MessageBox.Show("Succesfully deleted!");

                    ISaleRepositroy saleRepositroy = new SaleRepositroy();
                    saleRepositroy.DeleteSale(selectedIds);
                    RefreshSalesTable();
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



