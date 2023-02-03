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
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;
using ADO.NET_Helper;

namespace OrderManagementSystem
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            RefreshUserTable();
        }

        public void RefreshUserTable()
        {
            IUserRepository userRepository = new UserRepository();
            SqlDataReader sqlDataReader = userRepository.GetAllUsers(out SqlConnection sqlConnection);
            ControlFiller controlFiller = new();

            controlFiller.FillControlDataSource(tblUsers, sqlDataReader);
            tblUsers.ClearSelection();
            sqlConnection.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            FrmSaveUsers frmSaveUsers = new();
            frmSaveUsers.userId = -1;
            frmSaveUsers.usersForm = this;
            frmSaveUsers.Show();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmSaveUsers frmSaveUsers = new();

            if (tblUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return;
            }
            else
            {
                frmSaveUsers.userId = (int)tblUsers.SelectedRows[0].Cells["Id"].Value;
                frmSaveUsers.usersForm = this;
                frmSaveUsers.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          DialogResult result =  MessageBox.Show("Are you sure to delete?",caption: "Attention", icon:MessageBoxIcon.Question, buttons: MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {


                if (tblUsers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a product!", caption: "Attention", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                    return;
                }
                List<int> selectedIds = new List<int>();

                foreach (DataGridViewRow row in tblUsers.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    selectedIds.Add(id);
                }
                MessageBox.Show("Succesfully deleted!");

                IUserRepository userRepository = new UserRepository();
                userRepository.DeleteUsers(selectedIds);
                RefreshUserTable();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {

            IUserRepository userRepository = new UserRepository();
            string randomPassword = CommonTools.GenerateRandomPassword(6);
            int userId = (int)tblUsers.SelectedRows[0].Cells["Id"].Value;
            string email = tblUsers.SelectedRows[0].Cells["Email"].Value.ToString();
            string userName = tblUsers.SelectedRows[0].Cells["Name"].Value.ToString();

            string seperator = new string('-',90);
            string fileformat = $"{seperator}{Environment.NewLine}{Environment.NewLine}Your password has been resetted. New credentials to login your account: \nUsername: {userName} \nPassword: {randomPassword} {Environment.NewLine}{Environment.NewLine} {seperator}";

            CommonTools.SendEmail($"{email}", $"Order Managemet System",$"{fileformat}");
            userRepository.ChangePassword(userId,CryptographyManager.GetEncrypt(randomPassword));
            MessageBox.Show("Password succesfully resetted!");
            RefreshUserTable();
        }
    }
}   
