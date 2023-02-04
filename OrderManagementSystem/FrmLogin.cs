
using ADO.NET_Helper;
using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;
using System.Data.SqlClient;

namespace OrderManagementSystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            IUserRepository userRepository = new UserRepository();
            User user = userRepository.AuthenticateUser(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {


                SqlHelper sqlHelper = new SqlHelper();
                List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@UserId", user.Id),
            };
                sqlHelper.ExecuteNonQuery(query: " insert into LogTable(UserId) Values(@UserId); ", parameters: parameters);


                if (user.ChangePassword)
                {
                    MessageBox.Show("You have to change your password", caption: "Attention", icon: MessageBoxIcon.Information, buttons: MessageBoxButtons.OK);
                    FrmChangePassword frmChangePassword = new();
                    frmChangePassword.UserForm = user;
                    frmChangePassword.Show();
                    this.Hide();
                }
                else
                {
                    FrmMainMenu frmMainMenu = new FrmMainMenu();
                    frmMainMenu.UserData = user;
                    frmMainMenu.Show(this);
                    this.Hide();
                }
            }
            else
            {


                MessageBox.Show("Email or password is incorrect!", caption: "Login failed", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBoxPasswordShow.Checked;
        }


    }
}