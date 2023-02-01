using OrderManagementSystem.Entities;
using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;

namespace OrderManagementSystem
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        public User UserForm { get; set; }
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            txtEmail.Text = UserForm.Name;
            txtEmail.Enabled= false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfrimPassword.Text)
            {
                MessageBox.Show("Password and Confirm password are not same!", caption: "Error", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                return;
            }

            IUserRepository userRepository = new UserRepository();
            userRepository.ChangePassword(UserForm.Id,CryptographyManager.GetEncrypt(txtPassword.Text),changePassword:false);
            FrmMainMenu frmMainMenu = new();
            frmMainMenu.UserData = this.UserForm;
            frmMainMenu.Show();
            this.Close();
        }
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtConfrimPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

    }
}
