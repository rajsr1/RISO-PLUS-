using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Patient_Portal : Form
    {
        // ✅ FIXED CONNECTION STRING ✅
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                  Initial Catalog=RISO PLUS;
                  Integrated Security=True;";
        public Patient_Portal()
        {
            InitializeComponent();
        }

        // ✅ LOAD ALL PATIENT DATA INTO GRID
        private void LoadPatientData()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Patient", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ SEARCH BY NAME ✅ (NO ERROR VERSION)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("❌ Enter Patient Name");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string q = "SELECT Name FROM Patient WHERE Name LIKE @name";

                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text.Trim() + "%");

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show("✅ Patient Found: " + result.ToString());
                    }
                    else
                    {
                        MessageBox.Show("❌ Patient Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ VIEW DETAILS → SHOW ALL DATA IN GRID ✅
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            LoadPatientData();
        }

        // ✅ GRID CLICK → SHOW SMALL DETAILS ✅
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells["Name"].Value?.ToString();
                string age = dataGridView1.CurrentRow.Cells["Age"].Value?.ToString();
                string disease = dataGridView1.CurrentRow.Cells["Disease"].Value?.ToString();

                MessageBox.Show(
                    "Patient Info:\n\n" +
                    "Name: " + name +
                    "\nAge: " + age +
                    "\nDisease: " + disease
                );
            }
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Doc_Dashboard().Show();
        }

        private void Patient_Portal_Load(object sender, EventArgs e)
        {
            // Optional auto load
            // LoadPatientData();
        }
    }
}