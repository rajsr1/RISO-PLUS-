using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Login : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                           Initial Catalog=RISO PLUS;
                           Integrated Security=True;
                           TrustServerCertificate=True";

        public Login()
        {
            InitializeComponent();

            txtpass.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // ✅ LOGIN BUTTON
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("Please enter Username ❌");
                return;
            }

            if (txtpass.Text == "")
            {
                MessageBox.Show("Please enter Password ❌");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // ✅ 1. CHECK DOCTOR TABLE
                string queryDoctor = "SELECT * FROM Doctor WHERE Username=@u AND Password=@p";

                SqlCommand cmdDoctor = new SqlCommand(queryDoctor, con);
                cmdDoctor.Parameters.AddWithValue("@u", txtuname.Text);
                cmdDoctor.Parameters.AddWithValue("@p", txtpass.Text);

                SqlDataReader drDoctor = cmdDoctor.ExecuteReader();

                if (drDoctor.Read())
                {
                    MessageBox.Show("Doctor Login ✅");

                    new Doc_Dashboard().Show();
                    this.Hide();
                    return;
                }

                drDoctor.Close(); // ✅ VERY IMPORTANT

                // ✅ 2. CHECK USER TABLE
                string queryUser = "SELECT Role FROM [User] WHERE Username=@u AND Password=@p";

                SqlCommand cmdUser = new SqlCommand(queryUser, con);
                cmdUser.Parameters.AddWithValue("@u", txtuname.Text);
                cmdUser.Parameters.AddWithValue("@p", txtpass.Text);

                SqlDataReader drUser = cmdUser.ExecuteReader();

                if (drUser.Read())
                {
                    string role = drUser["Role"].ToString();

                    MessageBox.Show("Login Successful ✅");

                    if (role == "Admin")
                    {
                        new Admin_Dashboard().Show();
                    }
                    else if (role == "Reception")
                    {
                        new Reception().Show();
                    }
                    else if (role == "Billing")   // ✅ THIS WAS MISSING
                    {
                        new Form1().Show();        // ✅ Billing Dashboard
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password ❌");
                }
            }
        }

        // ✅ FIX DESIGNER ERROR
        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            // Leave empty ✅
        }
    }
}