using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newman_Cinema
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text=="admin" && txtPassword.Text=="password")
            {
                MainMenu.AdminLoggedin = true;
                MessageBox.Show("Login Successful");
                this.Hide();
                MainMenu MainMenu1 = new MainMenu(); //back to menu after successful login
                MainMenu1.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Login Details");
            }
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.Show();
            this.Hide();
        }
    }
}
