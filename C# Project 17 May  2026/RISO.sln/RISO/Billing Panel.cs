using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Billing_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Billing_Panel()
        {
            InitializeComponent();
        }

        // ✅ FORM LOAD → AUTO LOAD GRID
        private void Billing_Panel_Load(object sender, EventArgs e)
        {
            LoadBilling();
        }

        // ✅ LOAD DATA INTO GRID
        private void LoadBilling()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT PatientName, PatientId, DoctorFee, TestCost, RoomCharge, TotalAmount, BillStatus FROM TotalBilling",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        // ✅ TOTAL BILL BUTTON
        private void btnTotalBill_Click(object sender, EventArgs e)
        {
            try
            {
                string pname = txtPatNam.Text;
                string pid = txtPatId.Text;

                decimal docFee = Convert.ToDecimal(txtDocFee.Text);
                decimal testCost = Convert.ToDecimal(txtTeCo.Text);
                decimal roomCharge = Convert.ToDecimal(txtRoCh.Text);

                string status = ComBOxBill.Text;

                decimal total = docFee + testCost + roomCharge;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string query = @"INSERT INTO TotalBilling
                    (PatientName, PatientId, DoctorFee, TestCost, RoomCharge, TotalAmount, BillStatus)
                    VALUES (@n, @id, @df, @tc, @rc, @total, @status)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@n", pname);
                    cmd.Parameters.AddWithValue("@id", pid);
                    cmd.Parameters.AddWithValue("@df", docFee);
                    cmd.Parameters.AddWithValue("@tc", testCost);
                    cmd.Parameters.AddWithValue("@rc", roomCharge);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();
                }

                // ✅ IMPORTANT: REFRESH GRID AFTER INSERT 🔥
                LoadBilling();
            }
            catch
            {
                MessageBox.Show("❌ Please enter valid values!");
            }
        }

        // ✅ GRID CLICK → AUTO FILL FORM ✅🔥
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtPatNam.Text = dataGridView1.CurrentRow.Cells["PatientName"].Value.ToString();
                txtPatId.Text = dataGridView1.CurrentRow.Cells["PatientId"].Value.ToString();
                txtDocFee.Text = dataGridView1.CurrentRow.Cells["DoctorFee"].Value.ToString();
                txtTeCo.Text = dataGridView1.CurrentRow.Cells["TestCost"].Value.ToString();
                txtRoCh.Text = dataGridView1.CurrentRow.Cells["RoomCharge"].Value.ToString();
                ComBOxBill.Text = dataGridView1.CurrentRow.Cells["BillStatus"].Value.ToString();
            }
        }

        // ✅ FIX DESIGNER ERROR
        private void label2_Click(object sender, EventArgs e)
        {
            // empty ✅
        }
    }
}
