using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Payment___Invoice_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Payment___Invoice_Panel()
        {
            InitializeComponent();
        }

        // ✅ FORM LOAD (optional)
        private void Payment___Invoice_Panel_Load(object sender, EventArgs e)
        {
            // optional load
        }

        // ✅ SEARCH BUTTON
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = @"SELECT PatientId, PatientName, TotalAmount 
                                 FROM TotalBilling 
                                 WHERE PatientId LIKE @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtPatId.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ GRID CLICK → AUTO FILL
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtPatId.Text = dataGridView1.CurrentRow.Cells["PatientId"].Value.ToString();
                txtPatNam.Text = dataGridView1.CurrentRow.Cells["PatientName"].Value.ToString();
                txtTotalAmount.Text = dataGridView1.CurrentRow.Cells["TotalAmount"].Value.ToString();
            }
        }

        // ✅ CREATE INVOICE
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = @"INSERT INTO Invoice
                (InvoiceID, PatientId, PatientName, TotalAmount)
                VALUES (@iid, @pid, @pname, @total)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@iid", txtInvoiceID.Text);
                cmd.Parameters.AddWithValue("@pid", txtPatId.Text);
                cmd.Parameters.AddWithValue("@pname", txtPatNam.Text);
                cmd.Parameters.AddWithValue("@total", txtTotalAmount.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Invoice Created Successfully");
            }
        }

        // ✅ BACK BUTTON (VERY IMPORTANT 🔥)
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        // ✅ IMPORTANT FIX (DO NOT REMOVE)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // keep empty ✅
        }

        // ✅ FIX TEXTBOX EVENTS
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // empty ✅
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // empty ✅
        }
    }
}