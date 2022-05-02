using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Newman_Cinema
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtPassword.Text != "")
            {
                MainMenu.con.ConnectionString = DBaseConn.ConnectionString;
                MainMenu.cmd = new OleDbCommand();
                MainMenu.cmd.Connection = MainMenu.con;

                try
                {
                    MainMenu.con.Open();

                    OleDbCommand command = new OleDbCommand("SELECT * from CustomersTable WHERE EmailAdd ='"  + txtEmail.Text + "'", MainMenu.con);
                    MainMenu.reader = command.ExecuteReader();

                    MainMenu.newMembers.Clear(); //if a user is currently logged in they are logged out

                    while (MainMenu.reader.Read())
                    {
                        MainMenu.newMembers.Add(new Members(MainMenu.reader[1].ToString(), MainMenu.reader[2].ToString(), MainMenu.reader[3].ToString(), MainMenu.reader[4].ToString()));
                    }

                    if (txtPassword.Text == MainMenu.newMembers[Members.i].Password)
                    {
                        MainMenu.CurrentMember = Members.i;
                        MessageBox.Show("Login Successful");
                        this.Hide();
                        MainMenu MainMenu1 = new MainMenu();
                        MainMenu1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }

                    MainMenu.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MainMenu.con.Close();
            }
            else
            {
                MessageBox.Show("Please fill all boxes");
            }

        }

        private void linklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp SignUp1 = new SignUp(); //go to signup form
            SignUp1.Show();
            this.Close();
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu1 = new MainMenu(); //return to menu
            MainMenu1.Show();
            this.Close();
        }
    }
}
