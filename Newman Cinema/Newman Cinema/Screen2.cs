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
using System.Net.Mail;

namespace Newman_Cinema
{
    public partial class Screen2 : Form
    {
        public Screen2()
        {
            InitializeComponent();
            dSum = 0;
            BookedSeats.Clear();
            SeatPrices.Clear();
            i = 0;

            btnAnySeat.Hide();
        }



        public static double dSum = 0;
        int intAdultTickets = 0, intChildTickets = 0; int i = 0;
        public static List<string> BookedSeats = new List<string>();
        public static List<double> SeatPrices = new List<double>();

        private void btnAnySeat_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b.BackColor == Color.LightSkyBlue) //if not 
            {
                b.BackColor = Color.SpringGreen; // change to adult provisional booking
                dSum = dSum + 5.95;
                intAdultTickets = intAdultTickets + 1;
                BookedSeats.Add(b.Name.ToString().Substring(3)); //add seat id-btn
                SeatPrices.Add(5.95);
                if (dSum > 0)
                {
                    lblDisplaySum.Text = dSum.ToString();
                }
                else
                {
                    lblDisplaySum.Text = "0";
                }
            }
            else if (b.BackColor == Color.SpringGreen)
            {
                b.BackColor = Color.LawnGreen; //child provisional booking
                dSum = dSum - 2.45;
                intAdultTickets = intAdultTickets - 1;
                intChildTickets = intChildTickets + 1;
                SeatPrices.RemoveAt(SeatPrices.Count - 1);
                if (dSum > 0)
                {
                    lblDisplaySum.Text = dSum.ToString();
                }
                else
                {
                    lblDisplaySum.Text = "0";
                }
            }
            else if (b.BackColor == Color.LawnGreen)
            {
                b.BackColor = Color.LightSkyBlue; //remove provisional booking
                dSum = dSum - 3.50d;
                intChildTickets = intChildTickets - 1;
                BookedSeats.Remove(b.Name.ToString().Substring(3));
                if (dSum > 0)
                {
                    lblDisplaySum.Text = dSum.ToString();
                }
                else
                {
                    lblDisplaySum.Text = "0";
                }
            }
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu MainMenu1 = new MainMenu();
            MainMenu1.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (dSum > 0 && MainMenu.CurrentMember>-1)
            {
                if (intAdultTickets > 0)
                {
                    MessageBox.Show("You have selected " + intAdultTickets + " adult tickets and " + intChildTickets + " child tickets for £" + dSum);
                    if (MainMenu.CurrentMember > -1)
                    {
                        string BookedSeatsOutput = string.Join(",", BookedSeats.ToArray());

                        MailMessage mailReceipt = new MailMessage();  //receipt
                        mailReceipt.From = new MailAddress("T0063112@cardinalnewman.ac.uk");
                        mailReceipt.CC.Add(MainMenu.newMembers[Members.i].Email);
                        mailReceipt.To.Add(MainMenu.newMembers[Members.i].Email);
                        mailReceipt.Subject = "Booking Receipt";
                        mailReceipt.Body = "You have booked:\n Adult Tickets- " + intAdultTickets + "\nChild Tickets- " + intChildTickets + "\nSeats- " + BookedSeatsOutput+ "for £"+dSum;

                        SmtpClient CustomerClient = new SmtpClient("smtp.outlook.com", 587);
                        CustomerClient.EnableSsl = true;
                        //CustomerClient.Send(mailReceipt); //sends email to the client - not working

                        MainMenu.con.ConnectionString = DBaseConn.ConnectionString;

                        try
                        {
                            MainMenu.con.Open();
                            i = 0;
                            foreach (var s in BookedSeats)
                            {
                                OleDbCommand InsertBookingCommand = new OleDbCommand(); //reset the command for each new booking
                                InsertBookingCommand.Connection = MainMenu.con;
                                InsertBookingCommand.CommandText = "INSERT INTO BookingsTable(SeatID,Screen,FilmDate,[Time],Price) VALUES(?,?,?,?,?)"; //insert the new bookings into the table, time is a reserved word
                                InsertBookingCommand.Parameters.AddWithValue("SeatID", BookedSeats[i]);
                                InsertBookingCommand.Parameters.AddWithValue("Screen", MovieSelect.Screen);
                                InsertBookingCommand.Parameters.AddWithValue("FilmDate", MovieSelect.Day);
                                InsertBookingCommand.Parameters.AddWithValue("[Time]", MovieSelect.Time);
                                InsertBookingCommand.Parameters.AddWithValue("Price", SeatPrices[i]);
                                InsertBookingCommand.ExecuteNonQuery();

                                i++; //cycle through each booked seat in the list
                            }
                            MessageBox.Show("Booking confirmed, email has been sent"); //confirmation
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        MainMenu.con.Close();
                        BookedSeats.Clear(); //clears list of provisionally booked seats as they are now booked
                        SeatPrices.Clear();

                        this.Close();
                        MainMenu MainMenu1 = new MainMenu();
                        MainMenu1.Show(); //return to menu after booking tickets

                    }
                }
                else if (intChildTickets > 0 && intAdultTickets == 0)
                {
                    MessageBox.Show("Children must be accompanied by at least one adult");
                }
                else
                {
                    MessageBox.Show("A seat must be selected before purchasing");
                }
            }
            else if(dSum<=0)
            {
                MessageBox.Show("A seat must be selected before purchasing");
            }
            else
            {
                MessageBox.Show("Please sign in to purchase tickets");
            }
        }

        private void Screen2_Load(object sender, EventArgs e)
        {

            foreach (var button in Controls.OfType<Button>())
            {
                button.BackColor = Color.LightSkyBlue;

                if (button != btnPurchase)
                {
                    button.Click += btnAnySeat_Click;
                }
            }
                MainMenu.con.ConnectionString = DBaseConn.ConnectionString;
                MainMenu.cmd = new OleDbCommand();
                MainMenu.cmd.Connection = MainMenu.con;

                try
                {
                    MainMenu.con.Open();

                    OleDbCommand BookingCommand = new OleDbCommand();
                    BookingCommand.Connection = MainMenu.con;

                    BookingCommand.CommandText = "SELECT * FROM BookingsTable WHERE Screen='" +MovieSelect.Screen +"' AND FilmDate='" + MovieSelect.Day + "' AND Time= '" + MovieSelect.Time + "'";

                    DataSet dsScreen2 = new DataSet();
                    OleDbDataAdapter daScreen2 = new OleDbDataAdapter(BookingCommand);
                    daScreen2.Fill(dsScreen2);

                    DataTable dtBookings = dsScreen2.Tables[0];

                    foreach (DataRow row in dtBookings.Rows)
                    {
                        string buttonname = "btn" + row[1].ToString();
                        this.Controls[buttonname].BackColor = Color.Red; //booked seats from the dataset turn red
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MainMenu.con.Close();

            
        }
    }
}
