using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Manage_Departments : Form
    {
        // ✅ connection string
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                           Initial Catalog=RISO PLUS;
                           Integrated Security=True;
                           TrustServerCertificate=True";

        // ✅ constructor
        public Manage_Departments()
        {
            InitializeComponent();
        }

        // ✅ FORM LOAD (OPTIONAL)
        private void Manage_Departments_Load(object sender, EventArgs e)
        {
            // nothing needed ✅
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Close();
        }

        // ✅ SHOW BUTTON (MAIN LOGIC 🔥)
        private void btnShow_click(object sender, EventArgs e)
        {
            if (CB1.Text == "")
            {
                MessageBox.Show("Please select a table!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string query = "SELECT * FROM dbo." + CB1.Text;

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // ✅ bind to DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ GRID CLICK (SAFE)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // optional ✅
        }
    }
}
