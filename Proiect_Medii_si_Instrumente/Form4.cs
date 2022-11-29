using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_Medii_si_Instrumente
{
    public partial class Form4 : Form
    {
        #region Private fields
        private readonly string connString = "Server=Raducu-PC2; Database=BazarAuto; Trusted_Connection=True;";
        #endregion

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Alege un fisier de tip imagine.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            byte[] arr;
            var converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            var conn = new SqlConnection(connString);
            conn.Open();
            var sql = "INSERT INTO Images (ImagePath, Brand, Model, Mileage, Year, Price, Sold) VALUES (@arr, @brand, @model, @mileage, @year, @price, 0)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@arr", arr);
            command.Parameters.AddWithValue("@brand", brandLabel.Text);
            command.Parameters.AddWithValue("@model", modelLabel.Text);
            command.Parameters.AddWithValue("@mileage", kmLabel.Text);
            command.Parameters.AddWithValue("@year", anLabel.Text);
            command.Parameters.AddWithValue("@price", pretLabel.Text);
            try
            {
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Vehicul adaugat.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ceva nu a mers bine, reincearca.");
            }
            
        }
    }
}
