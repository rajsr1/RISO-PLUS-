using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Appointment_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Appointment_Panel()
        {
            InitializeComponent();
        }

        // ✅ LOAD DATA
        private void LoadAppointments()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Appointment", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ BOOK (INSERT)
        private void btnBook_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"INSERT INTO Appointment
                (Name, Age, Gender, AppointmentDate, Reason, Specialist, Doctor)
                VALUES (@n, @a, @g, @d, @r, @s, @do)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtAddAppoint.Text);
                cmd.Parameters.AddWithValue("@a", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@r", txtRea.Text);
                cmd.Parameters.AddWithValue("@s", ComboBoxSpeci.Text);
                cmd.Parameters.AddWithValue("@do", txtDoctor.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Appointment Booked");

                LoadAppointments();
            }
        }

        // ✅ SHOW
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

                string gender = radioMale.Checked ? "Male" : "Female";

                string query = @"UPDATE Appointment
                SET Name=@n, Age=@a, Gender=@g, AppointmentDate=@d,
                    Reason=@r, Specialist=@s, Doctor=@do
                WHERE AppointmentID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtAddAppoint.Text);
                cmd.Parameters.AddWithValue("@a", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@r", txtRea.Text);
                cmd.Parameters.AddWithValue("@s", ComboBoxSpeci.Text);
                cmd.Parameters.AddWithValue("@do", txtDoctor.Text);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Updated");

                LoadAppointments();
            }
        }

        // ✅ CANCEL (DELETE)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

                string query = "DELETE FROM Appointment WHERE AppointmentID=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("❌ Appointment Cancelled");

                LoadAppointments();
            }
        }

        // ✅ GRID CLICK AUTO FILL ✅🔥
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.CurrentRow != null)
            {
                txtAddAppoint.Text = dataGridView1.CurrentRow.Cells["Name"].Value?.ToString();
                txtAge.Text = dataGridView1.CurrentRow.Cells["Age"].Value?.ToString();
                txtRea.Text = dataGridView1.CurrentRow.Cells["Reason"].Value?.ToString();
                ComboBoxSpeci.Text = dataGridView1.CurrentRow.Cells["Specialist"].Value?.ToString();
                txtDoctor.Text = dataGridView1.CurrentRow.Cells["Doctor"].Value?.ToString();

                if (dataGridView1.CurrentRow.Cells["AppointmentDate"].Value != null)
                {
                    dateTimePicker1.Value =
                        Convert.ToDateTime(dataGridView1.CurrentRow.Cells["AppointmentDate"].Value);
                }

                string gender = dataGridView1.CurrentRow.Cells["Gender"].Value?.ToString();

                if (gender == "Male") radioMale.Checked = true;
                else radioFemale.Checked = true;
            }
        }

        // ✅ BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Reception().Show();
        }
    }
}