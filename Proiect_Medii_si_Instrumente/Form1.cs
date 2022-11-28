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
        private readonly string connString = "Server=Raducu-PC2; Database=BazarAuto; Trusted_Connection=True;";
        #endregion

        #region Private Methods
        private void RegisterUser()
        {
            SqlConnection conn = new SqlConnection(connString);
            var sql = "INSERT INTO Users VALUES (@username, @password)";
            var sql2 = "SELECT * FROM USERS WHERE username = @username";
            try
            {
                SqlCommand command2 = new SqlCommand(sql2, conn);
                command2.Parameters.AddWithValue("@username", usernameReg.Text);
                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Deja mai exista unu' ca tine! Alege alt username.");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@username", usernameReg.Text);
                    command.Parameters.AddWithValue("@password", passwordReg.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Te-am bagat in sistem!");
                    usernameReg.Text = null;
                    passwordReg.Text = null;
                    confPassReg.Text = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed!");
                conn.Close();
            }
        }

        private void LoginUser()
        {
            SqlConnection conn = new SqlConnection(connString);
            var sql = "SELECT * FROM USERS WHERE username = @username AND password = @password";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", usernameLogin.Text);
            command.Parameters.AddWithValue("@password", passwordLogin.Text);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("User-ul exista.");
                conn.Close();
                usernameLogin.Text = null;
                passwordLogin.Text = null;
            }
            else
            {
                MessageBox.Show("N-ai cont veric'.");
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
            if (usernameReg.Text != string.Empty && passwordReg.Text != string.Empty && passwordReg.Text == confPassReg.Text)
            {
                RegisterUser();
            }
            else
            {
                MessageBox.Show("Mai verifica datele patron.");
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginUser();
        }
    }
}
