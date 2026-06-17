using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Prescription_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Prescription_Panel()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Doc_Dashboard().Show();
        }

        // ✅ SEARCH PATIENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                string query;

                int id;

                // ✅ Check if numeric input
                if (int.TryParse(txtSearch.Text, out id))
                {
                    // ✅ search by PID
                    query = "SELECT PID, Name, Disease FROM Patient WHERE PID=@id";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    // ✅ search by Name
                    query = "SELECT PID, Name, Disease FROM Patient WHERE Name LIKE @name";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // ✅ auto fill disease
                if (dt.Rows.Count > 0)
                {
                    txtDiseases.Text = dt.Rows[0]["Disease"].ToString();
                }
                else
                {
                    MessageBox.Show("❌ Patient Not Found");
                }
            }
        }

        // ✅ GRID CLICK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtSearch.Text = dataGridView1.CurrentRow.Cells["PID"].Value.ToString();
            txtDiseases.Text = dataGridView1.CurrentRow.Cells["Disease"].Value.ToString();
        }

        // ✅ ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("❌ Select patient from grid!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // ✅ GET REAL PID FROM GRID (IMPORTANT 🔥)
                int pid = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["PID"].Value);

                string query = "INSERT INTO Prescription (PID, Diseases, Medicine) VALUES (@pid,@d,@m)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid", pid);  // ✅ FIXED
                cmd.Parameters.AddWithValue("@d", txtDiseases.Text);
                cmd.Parameters.AddWithValue("@m", txtMed.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Prescription Added");
            }
        }


        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("❌ Please select a patient from grid!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // ✅ GET REAL PID FROM GRID ✅
                int pid = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["PID"].Value);

                string query = @"UPDATE Prescription 
                         SET Diseases=@d, Medicine=@m 
                         WHERE PID=@pid";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid", pid);   // ✅ FIXED
                cmd.Parameters.AddWithValue("@d", txtDiseases.Text);
                cmd.Parameters.AddWithValue("@m", txtMed.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Prescription Updated");
            }
        }


        // ✅ DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = "DELETE FROM Prescription WHERE PID=@pid";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid", txtSearch.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Deleted Successfully");
            }
        }
    }
}