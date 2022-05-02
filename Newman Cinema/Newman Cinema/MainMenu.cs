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
using System.Timers;

namespace Newman_Cinema
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            con = new OleDbConnection();
            con.ConnectionString = DBaseConn.ConnectionString;
            cmd = new OleDbCommand();
            con.Open();
            con.Close();

            if (CurrentMember>-1)
            {
                lblUser.Text = newMembers[CurrentMember].FName + "\nLogout";
            }
            else
            {
                lblUser.Text = "Not Logged In";
            }

            //imgTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //imgTimer.Interval = 3000;

            if (AdminLoggedin==true)
            {
                linkLabelAdminLogin.Text = "Admin Logout";
            }
            else
            {
                linkLabelAdminLogin.Text = "Admin Login";
            }

        }

        //System.Timers.Timer imgTimer = new System.Timers.Timer();

        public static OleDbConnection con;
        public static OleDbCommand cmd;
        public static OleDbDataReader reader;

        public static List<Members> newMembers = new List<Members>();

        public static int CurrentMember=-1;

        public static bool AdminLoggedin = false;

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn Login1 = new LogIn();
            Login1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin AdminLogin1 = new AdminLogin();
            AdminLogin1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp SignUp1 = new SignUp();
            SignUp1.Show();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            MovieSelect MovieSelect1 = new MovieSelect();
            MovieSelect1.Show();
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (CurrentMember>-1)
            {
                newMembers.Clear();
                CurrentMember = CurrentMember - 1;
                MessageBox.Show("Logged out");
                lblUser.Text = "Not Logged In";
            }
            else
            {
                this.Hide();
                LogIn Login1 = new LogIn();
                Login1.Show();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            int i = 0;
            while (i<5)
            {
                pBoxFilms.BackgroundImage = imgListFilms.Images[i];
                if (i==4)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            
        }

        private void linkLabelAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AdminLoggedin==true)
            {
                AdminLoggedin = false;
                linkLabelAdminLogin.Text = "Admin Login";
            }
            else
            {
                this.Hide();
                AdminLogin AdminLogin1 = new AdminLogin();
                AdminLogin1.Show();
            }

        }

        private void btnComingSoon_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coming_Soon ComingSoon1 = new Coming_Soon();
            ComingSoon1.Show();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
