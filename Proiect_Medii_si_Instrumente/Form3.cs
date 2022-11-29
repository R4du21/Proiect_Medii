using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
                if (sold == "0")
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel1.Text = (string)reader["Brand"];
                    modelLabel1.Text = (string)reader["Model"];
                    kmLabel1.Text = (string)reader["Mileage"];
                    yearLabel1.Text = (string)reader["Year"];
                    priceLabel1.Text = (string)reader["Price"];
                    var ms = new MemoryStream(img);
                    VWimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel1.Text = (string)reader["Brand"];
                    modelLabel1.Text = (string)reader["Model"];
                    kmLabel1.Text = (string)reader["Mileage"];
                    yearLabel1.Text = (string)reader["Year"];
                    priceLabel1.Text = (string)reader["Price"];
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
                if (sold == "0")
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel2.Text = (string)reader["Brand"];
                    modelLabel2.Text = (string)reader["Model"];
                    kmLabel2.Text = (string)reader["Mileage"];
                    yearLabel2.Text = (string)reader["Year"];
                    priceLabel2.Text = (string)reader["Price"];
                    var ms = new MemoryStream(img);
                    Audiimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel2.Text = (string)reader["Brand"];
                    modelLabel2.Text = (string)reader["Model"];
                    kmLabel2.Text = (string)reader["Mileage"];
                    yearLabel2.Text = (string)reader["Year"];
                    priceLabel2.Text = (string)reader["Price"];
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
                if (sold == "0")
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel3.Text = (string)reader["Brand"];
                    modelLabel3.Text = (string)reader["Model"];
                    kmLabel3.Text = (string)reader["Mileage"];
                    yearLabel3.Text = (string)reader["Year"];
                    priceLabel3.Text = (string)reader["Price"];
                    var ms = new MemoryStream(img);
                    BMWimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel3.Text = (string)reader["Brand"];
                    modelLabel3.Text = (string)reader["Model"];
                    kmLabel3.Text = (string)reader["Mileage"];
                    yearLabel3.Text = (string)reader["Year"];
                    priceLabel3.Text = (string)reader["Price"];
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
                if (sold == "0")
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel4.Text = (string)reader["Brand"];
                    modelLabel4.Text = (string)reader["Model"];
                    kmLabel4.Text = (string)reader["Mileage"];
                    yearLabel4.Text = (string)reader["Year"];
                    priceLabel4.Text = (string)reader["Price"];
                    var ms = new MemoryStream(img);
                    Chevroletimage.Image = Image.FromStream(ms);
                    conn.Close();
                }
                else
                {
                    byte[] img = (byte[])reader["ImagePath"];
                    brandLabel4.Text = (string)reader["Brand"];
                    modelLabel4.Text = (string)reader["Model"];
                    kmLabel4.Text = (string)reader["Mileage"];
                    yearLabel4.Text = (string)reader["Year"];
                    priceLabel4.Text = (string)reader["Price"];
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
        #endregion

        private void cumpara1_Click(object sender, EventArgs e)
        {
            Car1Sold();
        }

        private void cumpara2_Click(object sender, EventArgs e)
        {
            Car2Sold();
        }

        private void cumpara3_Click(object sender, EventArgs e)
        {
            Car3Sold();
        }

        private void cumpara4_Click(object sender, EventArgs e)
        {
            Car4Sold();
        }
    }
}
