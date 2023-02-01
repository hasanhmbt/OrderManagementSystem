using OrderManagementSystem.Entities;
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
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        public User UserData { get; set; }
        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            lblUserName.Text = UserData.Name;
            lblUsertype.Text = UserData.IsAdmin ? "Admin" : "Operator";
            if (!UserData.IsAdmin) 
            {
             btnUsers.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();

        }

        private void FrmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FrmProducts frmProducts = new();
            frmProducts.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmSales frmSales = new FrmSales();
            frmSales.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FrmReports frmReports = new();
            frmReports.Show();
        }
    }
}
