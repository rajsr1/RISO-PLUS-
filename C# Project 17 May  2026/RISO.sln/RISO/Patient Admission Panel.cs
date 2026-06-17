using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Patient_Admission_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Patient_Admission_Panel()
        {
            InitializeComponent();
        }

        // ✅ LOAD DATA ON FORM START
        private void Patient_Admission_Panel_Load(object sender, EventArgs e)
        {
            LoadPatients();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        // ✅ LOAD FUNCTION
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

        // ✅ INSERT
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"INSERT INTO Patient
                (Name, Age, Gender, DOB, Disease, BedRoom, Doctor)
                VALUES (@n, @a, @g, @d, @dis, @bed, @doc)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtAddPatient.Text);
                cmd.Parameters.AddWithValue("@a", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@dis", txtDesease.Text);
                cmd.Parameters.AddWithValue("@bed", txtBedRoom.Text);
                cmd.Parameters.AddWithValue("@doc", txtDoctor.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Patient Added");

                LoadPatients();
            }
        }

        // ✅ SHOW
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"UPDATE Patient
                SET Age=@a, Gender=@g, DOB=@d, Disease=@dis,
                    BedRoom=@bed, Doctor=@doc
                WHERE Name=@n";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtAddPatient.Text);
                cmd.Parameters.AddWithValue("@a", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@dis", txtDesease.Text);
                cmd.Parameters.AddWithValue("@bed", txtBedRoom.Text);
                cmd.Parameters.AddWithValue("@doc", txtDoctor.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Patient Updated");

                LoadPatients();
            }
        }

        // ✅ DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    // ✅ GET CURRENT SELECTED PID
                    int pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);

                    // ✅ STEP 1 → DELETE FROM PatientAdmission FIRST
                    SqlCommand cmd1 = new SqlCommand(
                        "DELETE FROM PatientAdmission WHERE PID=@id", con);

                    cmd1.Parameters.AddWithValue("@id", pid);
                    cmd1.ExecuteNonQuery();

                    // ✅ STEP 2 → DELETE FROM Patient
                    SqlCommand cmd2 = new SqlCommand(
                        "DELETE FROM Patient WHERE PID=@id", con);

                    cmd2.Parameters.AddWithValue("@id", pid);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("✅ Patient Deleted Successfully");

                    // ✅ Reload Grid
                    LoadPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ GRID CLICK AUTO FILL ✅🔥
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtAddPatient.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                txtAge.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();
                txtDesease.Text = dataGridView1.CurrentRow.Cells["Disease"].Value.ToString();
                txtBedRoom.Text = dataGridView1.CurrentRow.Cells["BedRoom"].Value.ToString();
                txtDoctor.Text = dataGridView1.CurrentRow.Cells["Doctor"].Value.ToString();

                dateTimePicker1.Value =
                    Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DOB"].Value);

                string gender = dataGridView1.CurrentRow.Cells["Gender"].Value.ToString();

                if (gender == "Male")
                    radioMale.Checked = true;
                else
                    radioFemale.Checked = true;
            }
        }

        // ✅ BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Reception().Show();
        }
    }
}