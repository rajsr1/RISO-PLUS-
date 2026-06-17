using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Medicine_Stoke_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Medicine_Stoke_Panel()
        {
            InitializeComponent();
        }

        // ✅ FORM LOAD
        private void Medicine_Stoke_Panel_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
        }

        // ✅ QUANTITY TRACKING BUTTON
        private void btnQuantityTracking_Click(object sender, EventArgs e)
        {
            LoadQuantity();
        }

        // ✅ LOAD DATA (NAME + QUANTITY ONLY)
        private void LoadQuantity()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MedName AS [Medicine Name], Quantity FROM Medicine", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ GRID CLICK (optional select)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string qty = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                MessageBox.Show("Medicine: " + name + "\nQuantity: " + qty);
            }
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}