using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Medical_Profile : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Medical_Profile()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Doc_Dashboard().Show();
        }

        // ✅ SEARCH MEDICINE
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("❌ Enter Medicine Name");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = @"SELECT MID, MedicineName, Stock
                                 FROM StockMedicine
                                 WHERE MedicineName LIKE @name";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("❌ Medicine not found");
                }
            }
        }

        // ✅ VIEW ALL MEDICINE
        private void btnView_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MID, MedicineName, Stock FROM StockMedicine", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ GRID CLICK (OPTIONAL)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtSearch.Text =
                dataGridView1.CurrentRow.Cells["MedicineName"].Value.ToString();
        }
    }
}