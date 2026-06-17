using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Manage_Users : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                           Initial Catalog=RISO PLUS;
                           Integrated Security=True;
                           TrustServerCertificate=True";

        public Manage_Users()
        {
            InitializeComponent();
        }

        // ✅ CLEAR FORM
        private void ClearFields()
        {
            txtName.Clear();
            txtAge.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            richTextBox1.Clear();

            radioMale.Checked = false;
            radioFemale.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
        }

        // ✅ LOAD USERS
        private void LoadUsers()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ FORM LOAD
        private void Manage_Users_Load(object sender, EventArgs e)
        {
            LoadUsers();

            // ✅ GRID SETTINGS
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ✅ INSERT
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"INSERT INTO [User]
                (Name, Age, Gender, DOB, Address, Username, Password, Role)
                VALUES (@n, @a, @g, @d, @ad, @u, @p, @r)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@a", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ad", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@r", "Reception");

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Added ✅");

                LoadUsers();
                ClearFields();
            }
        }

        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"UPDATE [User]
                SET Name=@n, Age=@a, Gender=@g, DOB=@d, Address=@ad, Password=@p
                WHERE Username=@u";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@a", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ad", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Updated ✅");

                LoadUsers();
                ClearFields();
            }
        }

        // ✅ DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = "DELETE FROM [User] WHERE Username=@u";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Deleted ✅");

                LoadUsers();
                ClearFields();
            }
        }

        // ✅ SHOW
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // ✅ ✅ ✅ IMPORTANT FIX (AUTO FILL WORKING 🔥)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    txtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value?.ToString();
                    txtAge.Text = dataGridView1.CurrentRow.Cells["Age"].Value?.ToString();
                    txtUsername.Text = dataGridView1.CurrentRow.Cells["Username"].Value?.ToString();
                    txtPassword.Text = dataGridView1.CurrentRow.Cells["Password"].Value?.ToString();
                    richTextBox1.Text = dataGridView1.CurrentRow.Cells["Address"].Value?.ToString();

                    if (dataGridView1.CurrentRow.Cells["DOB"].Value != null)
                        dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DOB"].Value);

                    string gender = dataGridView1.CurrentRow.Cells["Gender"].Value?.ToString();

                    if (gender == "Male")
                        radioMale.Checked = true;
                    else
                        radioFemale.Checked = true;
                }
            }
            catch
            {
                // ignore errors safely
            }
        }

        // ✅ DO NOT ASSIGN THIS IN PROPERTIES
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Close();
        }
    }
}
