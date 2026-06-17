using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Patient_List_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Patient_List_Panel()
        {
            InitializeComponent();
        }

        // ✅ LOAD DATA
        private void LoadPatients()
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

        // ✅ SHOW BUTTON
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        // ✅ GRID CLICK → AUTO FILL ✅
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ✅ prevent header click
                if (e.RowIndex < 0)
                    return;

                if (dataGridView1.CurrentRow != null)
                {
                    txtListName.Text = dataGridView1.CurrentRow.Cells["Name"].Value?.ToString();
                    txtListAge.Text = dataGridView1.CurrentRow.Cells["Age"].Value?.ToString();
                    txtDesease.Text = dataGridView1.CurrentRow.Cells["Disease"].Value?.ToString();
                    txtBedRoom.Text = dataGridView1.CurrentRow.Cells["BedRoom"].Value?.ToString();
                    txtDoctor.Text = dataGridView1.CurrentRow.Cells["Doctor"].Value?.ToString();

                    // ✅ SAFE DATE FIX 🔥
                    if (dataGridView1.CurrentRow.Cells["DOB"].Value != null &&
                        dataGridView1.CurrentRow.Cells["DOB"].Value != DBNull.Value)
                    {
                        dateTimePicker1.Value =
                            Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DOB"].Value);
                    }

                    string gender = dataGridView1.CurrentRow.Cells["Gender"].Value?.ToString();

                    if (gender == "Male")
                        radioMale.Checked = true;
                    else
                        radioFemale.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                int pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"UPDATE Patient
                SET Name=@n, Age=@a, Gender=@g, DOB=@d,
                    Disease=@dis, BedRoom=@bed, Doctor=@doc
                WHERE PID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtListName.Text);
                cmd.Parameters.AddWithValue("@a", txtListAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@dis", txtDesease.Text);
                cmd.Parameters.AddWithValue("@bed", txtBedRoom.Text);
                cmd.Parameters.AddWithValue("@doc", txtDoctor.Text);
                cmd.Parameters.AddWithValue("@id", pid);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Patient Updated");

                LoadPatients();
            }
        }

        // ✅ DELETE (FIXED FOREIGN KEY ✅)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    int pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);

                    // ✅ First delete from child table
                    SqlCommand cmd1 = new SqlCommand(
                        "DELETE FROM PatientAdmission WHERE PID=@id", con);

                    cmd1.Parameters.AddWithValue("@id", pid);
                    cmd1.ExecuteNonQuery();

                    // ✅ Then delete from main table
                    SqlCommand cmd2 = new SqlCommand(
                        "DELETE FROM Patient WHERE PID=@id", con);

                    cmd2.Parameters.AddWithValue("@id", pid);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("✅ Patient Deleted");

                    LoadPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Reception().Show();
        }

        // ✅ FIX DESIGNER ERROR (IMPORTANT)
        private void txtListName_TextChanged(object sender, EventArgs e)
        {
            // empty ✅
        }
    }
}
