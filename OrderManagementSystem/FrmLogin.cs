
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

        private void OrderManagementSystem_Load(object sender, EventArgs e)
        {
            txtEmail.Text= "hasanhumbet2004@gmail.com";
            txtPassword.Text = "12345";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IUserRepository userRepository = new UserRepository();
            User user = userRepository.AuthenticateUser(txtEmail.Text,txtPassword.Text);

            if (user != null)
            {
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

                Directory.CreateDirectory("C:\\Users\\hasan\\Desktop\\log");
                StreamWriter sw = new StreamWriter("C:\\Users\\hasan\\Desktop\\log\\log.txt");


                string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string newDirectory = Path.Combine(currentDirectory, "Logs");
                Directory.CreateDirectory(newDirectory + "\\Logs");

                string seperator = new string('-', 60);

                sw.WriteLine($"\n{seperator}\nEmail: {txtEmail.Text}\nDate:{DateTime.Now.ToString()}\n{seperator}\n");

                sw.Close();



                MessageBox.Show("Email or password is incorrect!", caption: "Login failed", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
            }

            
            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@UserId", user.Id),
            };
            sqlHelper.ExecuteNonQuery(query: " insert into LogTable(UserId) Values(@UserId); ", parameters: parameters);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBoxPasswordShow.Checked;
        }

      
    }
}