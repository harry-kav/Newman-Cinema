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
    public partial class Coming_Soon : Form
    {
        public Coming_Soon()
        {
            InitializeComponent();

            if (MainMenu.AdminLoggedin == true)
            {
                lblAdminControls.Show();
                lblAdminControls1.Show();
                lblAdminControls2.Show();
                film1odt.Show();
                film1cdt.Show();
                film2odt.Show();
                film2cdt.Show();
                film3odt.Show();
                film3cdt.Show();
                btnAdminChange.Show();
            }
            else
            {
                lblAdminControls.Hide();
                lblAdminControls1.Hide();
                lblAdminControls2.Hide();
                film1odt.Hide();
                film1cdt.Hide();
                film2odt.Hide();
                film2cdt.Hide();
                film3odt.Hide();
                film3cdt.Hide();
                btnAdminChange.Hide();

            }
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.Show();
        }

        private void btnAdminChange_Click(object sender, EventArgs e)
        {
            foreach (var t in Controls.OfType<TextBox>())
            {
                if (t.Text != "") //if the textbox has been used
                {
                    string strEditName = "lbl" + t.Name; //name of target label

                    if (t.Name.Contains("odt")) //determines length of substring
                    {
                        this.Controls[strEditName].Text = "Opening Date: " + t.Text; //updates label
                    }
                    else if (t.Name.Contains("cdt")) //determines length of substring
                    {
                        this.Controls[strEditName].Text = "Closing Date: " + t.Text; //updates label
                    }
                    
                }
            }
        }

        private void pBoxFilm1_Click(object sender, EventArgs e)
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

        private void pBoxFilm3_Click(object sender, EventArgs e)
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
    }
}
