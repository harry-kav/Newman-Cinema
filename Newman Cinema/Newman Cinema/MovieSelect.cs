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
    public partial class MovieSelect : Form
    {
        public static string Screen, Time, Day;

        public MovieSelect()
        {
            InitializeComponent();

            dtDateSelector.MinDate = DateTime.Today;

            if (MainMenu.AdminLoggedin==true)
            {
                lblAdminControls.Show();  //show admin controls if the admin is logged in
                lblAdminControls1.Show();
                lblAdminControls2.Show();
                txtRating.Show();
                txtRating1.Show();
                txtRating2.Show();
                txtDuration.Show();
                txtDuration1.Show();
                txtDuration2.Show();
                txtCloseDate.Show();
                txtCloseDate1.Show();
                txtCloseDate2.Show();
                btnAdminChange.Show();
                lblIncome.Show();
                lblIncomeDisplay.Show();

                MainMenu.con.ConnectionString = DBaseConn.ConnectionString;

                try
                {
                    MainMenu.con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = MainMenu.con;
                    cmd.CommandText = "SELECT * FROM BookingsTable"; //gets income

                    DataSet dsPrices = new DataSet();
                    OleDbDataAdapter daPrices = new OleDbDataAdapter(cmd);
                    daPrices.Fill(dsPrices);

                    DataTable dtPrices = dsPrices.Tables[0];

                    foreach (DataRow row in dtPrices.Rows)
                    {
                        if (double.TryParse(row[5].ToString(), out _)==true)
                        {
                            PriceSum = PriceSum + double.Parse(row[5].ToString()); //add all income together
                        }
                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                lblIncomeDisplay.Text = PriceSum.ToString();//displayb income

            }
            else
            {
                lblAdminControls.Hide(); //hide admin controls if admin not logged in
                lblAdminControls1.Hide();
                lblAdminControls2.Hide();
                txtRating.Hide();
                txtRating1.Hide();
                txtRating2.Hide();
                txtDuration.Hide();
                txtDuration1.Hide();
                txtDuration2.Hide();
                txtCloseDate.Hide();
                txtCloseDate1.Hide();
                txtCloseDate2.Hide();
                btnAdminChange.Hide();
                lblIncome.Hide();
                lblIncomeDisplay.Hide();
                
            }

        }

        List<double> SeatPrices = new List<double>(); double PriceSum; //used for displaying income to admin
        
        
        private void linkLabel1700s1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime CloseDate = Convert.ToDateTime(lblCloseDate.Text); //maximum date
            if (CloseDate >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value) > DateTime.Now && CloseDate >= dtDateSelector.Value)//if the time is available
            {
                Screen = "1"; Time = "17:00"; Day = dtDateSelector.Value.ToShortDateString(); //selecting screen and day/time
                this.Hide();
                Screen1 Screen1 = new Screen1();
                Screen1.Show();
            }

            else if (CloseDate >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value.ToShortDateString()) < DateTime.Now)
            {
                Screen = "1"; Time = "17:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen1 Screen1 = new Screen1();
                Screen1.Show();
            }
            else
            {
                MessageBox.Show("This time is no longer available");
            }
        }

        private void linkLabel2030s1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime CloseDate = Convert.ToDateTime(lblCloseDate.Text); //maximum date
            if (CloseDate >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value) > DateTime.Now && CloseDate >= dtDateSelector.Value)
            {
                Screen = "1"; Time = "20:30"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen1 Screen1 = new Screen1();
                Screen1.Show();
            }

            else if (CloseDate >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value.ToShortDateString()) < DateTime.Now)
            {
                Screen = "1"; Time = "20:30"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen1 Screen1 = new Screen1();
                Screen1.Show();
            }
            else
            {
                MessageBox.Show("This time is no longer available");
            }
        }

        private void linkLabel1100s2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime CloseDate1 = Convert.ToDateTime(lblCloseDate1.Text); //maximum date
            if (CloseDate1 >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value) > DateTime.Now && CloseDate1 >= dtDateSelector.Value)
            {
                Screen = "2"; Time = "11:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen2 Screen2 = new Screen2();
                Screen2.Show();
            }

            else if (CloseDate1 >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value.ToShortDateString()) < DateTime.Now)
            {
                Screen = "2"; Time = "11:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen2 Screen2 = new Screen2();
                Screen2.Show();
            }
            else
            {
                MessageBox.Show("This time is no longer available");
            }
        }

        private void linkLabel2030s2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime CloseDate1 = Convert.ToDateTime(lblCloseDate1.Text); //maximum date
            if (CloseDate1 >= DateTime.Today && DateTime.Now < Convert.ToDateTime(dtDateSelector.Value) && CloseDate1 >= dtDateSelector.Value)
            {
                Screen = "2"; Time = "20:30"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen2 Screen2 = new Screen2();
                Screen2.Show();
            }
            else if (CloseDate1 >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value.ToShortDateString()) < DateTime.Now)
            {
                Screen = "2"; Time = "20:30"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen2 Screen2 = new Screen2();
                Screen2.Show();
            }
            else
            {
                MessageBox.Show("This time is no longer available");
            }
        }

        private void linkLabel1700s2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime CloseDate2 = Convert.ToDateTime(lblCloseDate2.Text); //maximum date
            if (CloseDate2 >= DateTime.Today && DateTime.Now < Convert.ToDateTime(dtDateSelector.Value) && CloseDate2 >= dtDateSelector.Value)
            {
                Screen = "2"; Time = "17:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen2 Screen2 = new Screen2();
                Screen2.Show();
            }

            else if (CloseDate2 >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value.ToShortDateString()) < DateTime.Now)
            {
                Screen = "2"; Time = "17:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen2 Screen2 = new Screen2();
                Screen2.Show();
            }
            else
            {
                MessageBox.Show("This time is no longer available");
            }
        }

        private void openFileDialogImageLoad_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MainMenu.AdminLoggedin == true)
            {
                OpenFileDialog openFileDialogImageLoad = new OpenFileDialog() //properties of file browser
                {
                    InitialDirectory = @"C:\",
                    RestoreDirectory = true,
                    Title = "Select Image",
                    DefaultExt = "png",
                    Filter = "Image Files(*.jpg,*.jpeg,*.bmp,*.png)|*.jpg;*.jpeg;*.bmp;*.png", //can only select image files
                    CheckFileExists = true, //check that the file is real
                    CheckPathExists = true
                };

                openFileDialogImageLoad.ShowDialog(); //open file browser

                if (openFileDialogImageLoad.ShowDialog()== DialogResult.OK)
                {
                    pBoxFilm1.ImageLocation = openFileDialogImageLoad.FileName; //image of picturebox is the selected image
                }
            }
        }

        private void pBoxFilm2_Click(object sender, EventArgs e)
        {
            if (MainMenu.AdminLoggedin == true)
            {
                OpenFileDialog openFileDialogImageLoad = new OpenFileDialog() //properties of file browser
                {
                    InitialDirectory = @"C:\",
                    RestoreDirectory = true,
                    Title = "Select Image",
                    DefaultExt = "png",
                    Filter = "Image Files(*.jpg,*.jpeg,*.bmp,*.png)|*.jpg;*.jpeg;*.bmp;*.png", //can only select image files
                    CheckFileExists = true, //check that the file is real
                    CheckPathExists = true
                };

                openFileDialogImageLoad.ShowDialog(); //open file browser

                if (openFileDialogImageLoad.ShowDialog() == DialogResult.OK)
                {
                    pBoxFilm2.ImageLocation = openFileDialogImageLoad.FileName; //image of picturebox is the selected image
                }
            }
        }

        private void MovieSelect_Load(object sender, EventArgs e)
        {

        }

        private void txtRating_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCloseDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRating1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDuration1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCloseDate1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRating2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDuration2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCloseDate2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAdminControls_Click(object sender, EventArgs e)
        {

        }

        private void lblAdminControls2_Click(object sender, EventArgs e)
        {

        }

        private void lblAdminControls1_Click(object sender, EventArgs e)
        {

        }

        private void pboxFilm3_Click(object sender, EventArgs e)
        {
            if (MainMenu.AdminLoggedin == true)
            {
                OpenFileDialog openFileDialogImageLoad = new OpenFileDialog() //properties of file browser
                {
                    InitialDirectory = @"C:\",
                    RestoreDirectory = true,
                    Title = "Select Image",
                    DefaultExt = "png",
                    Filter = "Image Files(*.jpg,*.jpeg,*.bmp,*.png)|*.jpg;*.jpeg;*.bmp;*.png", //can only select image files
                    CheckFileExists = true, //check that the file is real
                    CheckPathExists = true
                };

                openFileDialogImageLoad.ShowDialog(); //open file browser

                if (openFileDialogImageLoad.ShowDialog() == DialogResult.OK)
                {
                    pBoxFilm3.ImageLocation = openFileDialogImageLoad.FileName; //image of picturebox is the selected image
   
                }
            }
        }

        private void btnAdminChange_Click(object sender, EventArgs e)
        {
            foreach(var t in Controls.OfType<TextBox>())
            {
                if (t.Text!="") //if the textbox has been used
                {
                    string strEditName = "lbl" + t.Name.Substring(3); //name of target label

                    if (t.Name.Contains("Duration")) //determines length of substring
                    {
                        this.Controls[strEditName].Text = t.Name.Substring(3, 8) + ":" + t.Text; //updates label
                    }
                    else if (t.Name.Contains("Rating")) //determines length of substring
                    {
                        this.Controls[strEditName].Text = t.Name.Substring(3, 6) + ":" + t.Text; //updates label
                    }
                    else if (t.Name.Contains("CloseDate")) //determines length of substring
                    {
                        this.Controls[strEditName].Text = t.Name.Substring(3, 9) + ":" + t.Text; //updates label
                    }
                }
            }
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.Show();
            this.Hide();
        }

        private void linkLabel1020_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime CloseDate = Convert.ToDateTime(lblCloseDate.Text); //maximum date
            if (CloseDate >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value) > DateTime.Now && CloseDate>= dtDateSelector.Value)
            {
                Screen = "1"; Time = "11:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen1 Screen1 = new Screen1();
                Screen1.Show();
            }

            else if (CloseDate >= DateTime.Today && Convert.ToDateTime(dtDateSelector.Value.ToShortDateString()) < DateTime.Now)
            {
                Screen = "1"; Time = "11:00"; Day = dtDateSelector.Value.ToShortDateString();
                this.Hide();
                Screen1 Screen1 = new Screen1();
                Screen1.Show();
            }
            else
            {
                MessageBox.Show("This time is no longer available");
            }

        }
    }
}
