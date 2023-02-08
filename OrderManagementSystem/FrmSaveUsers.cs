using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;

namespace OrderManagementSystem
{
    public partial class FrmSaveUsers : Form
    {
        public FrmSaveUsers()
        {
            InitializeComponent();
        }

        public FrmUsers usersForm { get; set; }
        public int userId { get; set; }
        private void FrmSaveUsers_Load(object sender, EventArgs e)
        {
            if (userId == -1)
            {
                this.Text = "Add User";
            }
            else
            {
                this.Text = "Edit User";
                IUserRepository userRepository = new UserRepository();
                User user = userRepository.GetUserById(userId);
                if (user != null)
                {

                    txtUserName.Text = user.Name;
                    txtEmail.Text = user.Email;
                    txtPassword.Text = user.Password;

                }

            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

             
            IUserRepository userRepository = new UserRepository();

            if (userId == -1)
            {
                userRepository.AddUsers(new User {Name=txtUserName.Text,Email=txtEmail.Text,Password=txtPassword.Text });
            }
            else
            {
                userRepository.EditUser(new User {Id=userId, Name = txtUserName.Text, Email = txtEmail.Text, Password = txtPassword.Text, IsAdmin = checkBoxIsAdmin.Checked});
            }

            usersForm.RefreshUserTable();
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
