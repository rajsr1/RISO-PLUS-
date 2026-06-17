using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Manage_Doctors : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                           Initial Catalog=RISO PLUS;
                           Integrated Security=True;
                           TrustServerCertificate=True";

        public Manage_Doctors()
        {
            InitializeComponent();
        }

        // ✅ CLEAR
        private void ClearFields()
        {
            txtNameDoc.Clear();
            txtAgeDoc.Clear();
            txtUserDoc.Clear();
            txtPassDoc.Clear();
            richTextBoxAddress.Clear();

            radioMale.Checked = false;
            radioFemale.Checked = false;

            cbmbbs.Checked = false;
            cbfcps.Checked = false;
            cbmd.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
        }

        // ✅ LOAD
        private void LoadDoctors()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Doctor", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void Manage_Doctors_Load(object sender, EventArgs e)
        {
            LoadDoctors();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ✅ INSERT
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string degree = "";
                if (cbmbbs.Checked) degree += "MBBS ";
                if (cbfcps.Checked) degree += "FCPS ";
                if (cbmd.Checked) degree += "MD";

                string query = @"INSERT INTO Doctor
                (Name, Age, Gender, DOB, Degree, Dept_ID, Username, Password, Address)
                VALUES (@n, @a, @g, @d, @deg, @dept, @u, @p, @ad)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtNameDoc.Text);
                cmd.Parameters.AddWithValue("@a", txtAgeDoc.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@deg", degree);
                cmd.Parameters.AddWithValue("@dept", cmbDepartment.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@u", txtUserDoc.Text);
                cmd.Parameters.AddWithValue("@p", txtPassDoc.Text);
                cmd.Parameters.AddWithValue("@ad", richTextBoxAddress.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Doctor Added ✅");

                LoadDoctors();
                ClearFields();
            }
        }

        // ✅ UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string gender = radioMale.Checked ? "Male" : "Female";

                string degree = "";
                if (cbmbbs.Checked) degree += "MBBS ";
                if (cbfcps.Checked) degree += "FCPS ";
                if (cbmd.Checked) degree += "MD";

                string query = @"UPDATE Doctor
                SET Name=@n, Age=@a, Gender=@g, DOB=@d, Degree=@deg,
                    Address=@ad, Password=@p
                WHERE Username=@u";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@n", txtNameDoc.Text);
                cmd.Parameters.AddWithValue("@a", txtAgeDoc.Text);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@deg", degree);
                cmd.Parameters.AddWithValue("@ad", richTextBoxAddress.Text);
                cmd.Parameters.AddWithValue("@u", txtUserDoc.Text);
                cmd.Parameters.AddWithValue("@p", txtPassDoc.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Doctor Updated ✅");

                LoadDoctors();
                ClearFields();
            }
        }

        // ✅ DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string query = "DELETE FROM Doctor WHERE Username=@u";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", txtUserDoc.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Doctor Deleted ✅");

                LoadDoctors();
                ClearFields();
            }
        }

        // ✅ SHOW
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        // ✅ GRID CLICK FILL
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtNameDoc.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                txtAgeDoc.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();
                txtUserDoc.Text = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();
                txtPassDoc.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
                richTextBoxAddress.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();

                dateTimePicker1.Value =
                Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DOB"].Value);

                string gender = dataGridView1.CurrentRow.Cells["Gender"].Value.ToString();

                if (gender == "Male")
                    radioMale.Checked = true;
                else
                    radioFemale.Checked = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Admin_Dashboard().Show();
            this.Close();
        }
    }
}