using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Medicine_Management_panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Medicine_Management_panel()
        {
            InitializeComponent();
        }

        // ✅ CLEAR FORM
        private void ClearFields()
        {
            txtMedName.Clear();
            txtComName.Clear();
            txtPrice.Clear();

            dateTimePickerManu.Value = DateTime.Now;
            dateTimePickerEx.Value = DateTime.Now;
        }

        // ✅ LOAD DATA
        private void LoadMedicine()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Medicine", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ VIEW BUTTON
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadMedicine();
        }

        // ✅ ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = @"INSERT INTO Medicine
                (MedName, ManuDate, ExpDate, CompanyName, Price)
                VALUES (@name, @mdate, @edate, @company, @price)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", txtMedName.Text);
                cmd.Parameters.AddWithValue("@mdate", dateTimePickerManu.Value);
                cmd.Parameters.AddWithValue("@edate", dateTimePickerEx.Value);
                cmd.Parameters.AddWithValue("@company", txtComName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Medicine Added ✅");

                LoadMedicine();
                ClearFields();
            }
        }

        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MID"].Value);

                string query = @"UPDATE Medicine
                SET MedName=@name, ManuDate=@mdate, ExpDate=@edate,
                    CompanyName=@company, Price=@price
                WHERE MID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", txtMedName.Text);
                cmd.Parameters.AddWithValue("@mdate", dateTimePickerManu.Value);
                cmd.Parameters.AddWithValue("@edate", dateTimePickerEx.Value);
                cmd.Parameters.AddWithValue("@company", txtComName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Medicine Updated ✅");

                LoadMedicine();
                ClearFields();
            }
        }

        // ✅ DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MID"].Value);

                string query = "DELETE FROM Medicine WHERE MID=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Medicine Deleted ✅");

                LoadMedicine();
                ClearFields();
            }
        }

        // ✅ GRID CLICK AUTO FILL ✅🔥
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMedName.Text = dataGridView1.CurrentRow.Cells["MedName"].Value.ToString();
                txtComName.Text = dataGridView1.CurrentRow.Cells["CompanyName"].Value.ToString();
                txtPrice.Text = dataGridView1.CurrentRow.Cells["Price"].Value.ToString();

                dateTimePickerManu.Value =
                    Convert.ToDateTime(dataGridView1.CurrentRow.Cells["ManuDate"].Value);

                dateTimePickerEx.Value =
                    Convert.ToDateTime(dataGridView1.CurrentRow.Cells["ExpDate"].Value);
            }
        }

        // ✅ BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
