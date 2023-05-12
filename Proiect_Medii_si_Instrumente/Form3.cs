using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Proiect_Medii_si_Instrumente
{
    public partial class Form3 : Form
    {
        #region Private fields
        private readonly string connString = "Server=Raducu-PC2; Database=BazarAuto; Trusted_Connection=True;";
        #endregion

        public Form3()
        {
            InitializeComponent();
            Image1();
            Image2();
            Image3();
            Image4();
        }

        #region Private methods
        private void Car1Sold()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "UPDATE Images SET Sold = 1 WHERE ImageId = 1";
            var command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            vandut1.Show();
            cumpara1.Hide();
        }

        private void Car2Sold()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "UPDATE Images SET Sold = 1 WHERE ImageId = 2";
            var command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            vandut2.Show();
            cumpara2.Hide();
        }

        private void Car3Sold()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "UPDATE Images SET Sold = 1 WHERE ImageId = 3";
            var command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            vandut3.Show();
            cumpara3.Hide();
        }

        private void Car4Sold()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "UPDATE Images SET Sold = 1 WHERE ImageId = 4";
            var command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            vandut4.Show();
            cumpara4.Hide();
        }

        private void Image1()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "SELECT * FROM IMAGES WHERE ImageId = 1";
            var command = new SqlCommand(sql, conn);
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                var sold = (string)reader["Sold"];
                byte[] img = (byte[])reader["ImagePath"];
                brandLabel1.Text = (string)reader["Brand"];
                modelLabel1.Text = (string)reader["Model"];
                kmLabel1.Text = (string)reader["Mileage"];
                yearLabel1.Text = (string)reader["Year"];
                priceLabel1.Text = (string)reader["Price"];
                if (sold == "0")
                {
                    var ms = new MemoryStream(img);
                    VWimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    vandut1.Show();
                    cumpara1.Hide();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare pe traseu.");
            }

        }

        private void Image2()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "SELECT * FROM IMAGES WHERE ImageId = 2";
            var command = new SqlCommand(sql, conn);
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                var sold = (string)reader["Sold"];
                byte[] img = (byte[])reader["ImagePath"];
                brandLabel2.Text = (string)reader["Brand"];
                modelLabel2.Text = (string)reader["Model"];
                kmLabel2.Text = (string)reader["Mileage"];
                yearLabel2.Text = (string)reader["Year"];
                priceLabel2.Text = (string)reader["Price"];
                if (sold == "0")
                {
                    var ms = new MemoryStream(img);
                    Audiimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    vandut2.Show();
                    cumpara2.Hide();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare pe traseu.");
            }

        }

        private void Image3()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "SELECT * FROM IMAGES WHERE ImageId = 3";
            var command = new SqlCommand(sql, conn);
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                var sold = (string)reader["Sold"];
                byte[] img = (byte[])reader["ImagePath"];
                brandLabel3.Text = (string)reader["Brand"];
                modelLabel3.Text = (string)reader["Model"];
                kmLabel3.Text = (string)reader["Mileage"];
                yearLabel3.Text = (string)reader["Year"];
                priceLabel3.Text = (string)reader["Price"];
                if (sold == "0")
                {
                    var ms = new MemoryStream(img);
                    BMWimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    vandut3.Show();
                    cumpara3.Hide();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare pe traseu.");
            }

        }

        private void Image4()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "SELECT * FROM IMAGES WHERE ImageId = 4";
            var command = new SqlCommand(sql, conn);
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                var sold = (string)reader["Sold"];
                byte[] img = (byte[])reader["ImagePath"];
                brandLabel4.Text = (string)reader["Brand"];
                modelLabel4.Text = (string)reader["Model"];
                kmLabel4.Text = (string)reader["Mileage"];
                yearLabel4.Text = (string)reader["Year"];
                priceLabel4.Text = (string)reader["Price"];
                if (sold == "0")
                {
                    var ms = new MemoryStream(img);
                    Chevroletimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    vandut4.Show();
                    cumpara4.Hide();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare pe traseu.");
            }

        }

        private void BuyMusic()
        {
            SoundPlayer buy = new SoundPlayer(@"C:\VS Projects\Proiect_Medii_si_Instrumente\buymusic.wav");
            buy.Play();
        }

        private void PlayVideo(string link)
        {
            Form5 videoForm = new Form5(link);
            videoForm.Show();
        }

        #endregion

        private void cumpara1_Click(object sender, EventArgs e)
        {
            Car1Sold();
            BuyMusic();
        }

        private void cumpara2_Click(object sender, EventArgs e)
        {
            Car2Sold();
            BuyMusic();
        }

        private void cumpara3_Click(object sender, EventArgs e)
        {
            Car3Sold();
            BuyMusic();
        }

        private void cumpara4_Click(object sender, EventArgs e)
        {
            Car4Sold();
            BuyMusic();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var loadingForm = new Form2();
            this.Hide();
            loadingForm.Show();
        }

        private void video1_Click(object sender, EventArgs e)
        {
            var link = "https://www.youtube.com/watch?v=PGL_lVVG4us";
            PlayVideo(link);
        }

        private void video2_Click(object sender, EventArgs e)
        {
            var link = "https://www.youtube.com/watch?v=PVMdMKRXpOM";
            PlayVideo(link);
        }

        private void video3_Click(object sender, EventArgs e)
        {
            var link = "https://www.youtube.com/watch?v=U9Ai9EzaMns";
            PlayVideo(link);
        }

        private void video4_Click(object sender, EventArgs e)
        {
            var link = "https://www.youtube.com/watch?v=ztgWQmPH5r0";
            PlayVideo(link);
        }
    }
}
