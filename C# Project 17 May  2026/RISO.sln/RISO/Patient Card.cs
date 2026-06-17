using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Patient_Card : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Patient_Card()
        {
            InitializeComponent();
        }

        // ✅ SEARCH DOCTOR (MAIN FUNCTION)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // ✅ CHECK: input is number or text
                int id;
                if (int.TryParse(txtDoctor.Text, out id))
                {
                    // ✅ search by ID
                    query = @"SELECT DID, Name, Degree, Dept_ID, Username 
                      FROM Doctor 
                      WHERE DID = @id";

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    // ✅ search by Username or Name
                    query = @"SELECT DID, Name, Degree, Dept_ID, Username 
                      FROM Doctor 
                      WHERE Username = @txt OR Name LIKE @txt";

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@txt", "%" + txtDoctor.Text + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ OPTIONAL VIEW ALL DOCTORS
        private void btnView_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT DID, Name, Degree, Dept_ID, Username FROM Doctor", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ GRID CLICK (OPTIONAL)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.CurrentRow != null)
            {
                txtDoctor.Text = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Doc_Dashboard().Show();
        }
    }
}