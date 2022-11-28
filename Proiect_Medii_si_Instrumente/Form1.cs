using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proiect_Medii_si_Instrumente
{
    public partial class Form1 : Form
    {
        #region Private Fields
        private bool sidebarExpand = true;
        private bool sidebar2Expand = false;
        private readonly string DBString = "Server=Raducu-PC2; Database=BazarAuto; Trusted_Connection=True;";
        #endregion

        #region Private Methods
        private void RegisterUser()
        {
            string connString = DBString;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Users VALUES (@username, @password)", conn);
                command.Parameters.AddWithValue("@username", usernameReg.Text);
                command.Parameters.AddWithValue("@password", passwordReg.Text);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Te-ai inregistrat cu succes!");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed!");
                conn.Close();
            }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                    sidebarTimer2.Start();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                    if (sidebar2Expand)
                    {
                        sidebarTimer2.Start();

                    }
                }
            }
        }

        private void amcontButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void inapoiButton_Click(object sender, EventArgs e)
        {
            sidebarTimer2.Start();
        }

        private void sidebarTimer2_Tick(object sender, EventArgs e)
        {
            if (sidebar2Expand)
            {
                sidebarLeft.Width -= 10;
                if (sidebarLeft.Width == sidebarLeft.MinimumSize.Width)
                {
                    sidebar2Expand = false;
                    sidebarTimer2.Stop();
                    sidebarTimer.Start();
                }
            }
            else
            {
                sidebarLeft.Width += 10;
                if (sidebarLeft.Width == sidebarLeft.MaximumSize.Width)
                {
                    sidebar2Expand = true;
                    sidebarTimer2.Stop();
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(passwordReg.Text == confPassReg.Text)
            {
                RegisterUser();
            }
            else
            {
                MessageBox.Show("Passwords doesn't match!");
            }
        }
    }
}
