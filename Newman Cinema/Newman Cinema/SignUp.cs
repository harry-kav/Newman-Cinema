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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtFName.Text !="" && txtSName.Text != "" && txtEmail.Text != "" && txtPassword.Text != "")
            {
                if (txtEmail.Text.Contains("@")&& txtEmail.Text.Contains("."))
                {
                    MainMenu.newMembers.Add(new Members(txtFName.Text, txtSName.Text, txtEmail.Text, txtPassword.Text));

                    MainMenu.con.ConnectionString = DBaseConn.ConnectionString;
                    
                    

                    try
                    {
                        MainMenu.cmd = new OleDbCommand();
                        MainMenu.cmd.CommandType = CommandType.Text;

                        MainMenu.cmd.CommandText = "INSERT INTO CustomersTable (FName, SName, EmailAdd, Password1) VALUES(?,?,?,?)"; //add account to database
                        MainMenu.cmd.Parameters.AddWithValue("FName", txtFName.Text);
                        MainMenu.cmd.Parameters.AddWithValue("SName", txtSName.Text);
                        MainMenu.cmd.Parameters.AddWithValue("EmailAdd", txtEmail.Text);
                        MainMenu.cmd.Parameters.AddWithValue("Password1", txtPassword.Text);

                        MainMenu.cmd.Connection = MainMenu.con;

                        MainMenu.con.Open();

                        MainMenu.cmd.ExecuteNonQuery();

                        MessageBox.Show("Account Created Successfully", "Account Creation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MainMenu.newMembers.Add(new Members(txtFName.Text.ToString(), txtSName.Text.ToString(), txtEmail.Text.ToString(), txtPassword.Text.ToString())); //add as the current instance of the class
                        MainMenu.CurrentMember = Members.i; 

                        this.Hide();
                        MainMenu MainMenu1 = new MainMenu();
                        MainMenu1.Show();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    MainMenu.con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all boxes");
            }
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.Show();
            this.Hide();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
