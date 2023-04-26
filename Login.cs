using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataBase
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        Role role = new Role();

        private const int UserLogin = 1;
        private const int UserPassword = 1;
        private const int AdminLogin = 2;
        private const int AdminPassword = 2;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var login = int.Parse(textBox1.Text);
                var password = int.Parse(textBox2.Text);

                if (login == UserLogin && password == UserPassword)
                {
                    role.user = "user";
                }
                else if (login == AdminLogin && password == AdminPassword)
                {
                    role.admin = "admin";
                }
                else
                {
                    MessageBox.Show("Invalid login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Hide();
                Menu menu = new Menu(role);
                menu.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
