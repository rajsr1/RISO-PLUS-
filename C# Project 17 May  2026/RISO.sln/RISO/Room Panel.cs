using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RISO
{
    public partial class Room_Panel : Form
    {
        string connStr = @"Data Source=OMARFARUQ88A3\SQLEXPRESS;
                          Initial Catalog=RISO PLUS;
                          Integrated Security=True;
                          TrustServerCertificate=True";

        public Room_Panel()
        {
            InitializeComponent();
        }

        // ✅ LOAD DATA
        private void LoadRoomData()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM RoomAssign", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // ✅ SEARCH PATIENT
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("❌ Enter Patient ID");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string q = "SELECT * FROM Patient WHERE PID=@id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", txtSearch.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("✅ Patient Found: " + dr["Name"].ToString());
                }
                else
                {
                    MessageBox.Show("❌ Patient Not Found");
                }
            }
        }

        // ✅ ADD ROOM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtRoom.Text == "")
            {
                MessageBox.Show("❌ Fill all fields");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string discharge = radioYes.Checked ? "Yes" : "No";

                string query = @"INSERT INTO RoomAssign
                (PID, RoomNo, Discharge)
                VALUES (@pid, @room, @dis)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid", txtSearch.Text);
                cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                cmd.Parameters.AddWithValue("@dis", discharge);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Room Assigned");

                LoadRoomData(); // refresh
            }
        }

        // ✅ SHOW ALL
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadRoomData();
        }

        // ✅ UPDATE (DISCHARGE)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("❌ Please select a row first!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string discharge = radioYes.Checked ? "Yes" : "No";

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RAID"].Value);

                string query = @"UPDATE RoomAssign
                                 SET Discharge=@dis
                                 WHERE RAID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@dis", discharge);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Updated Successfully");

                LoadRoomData();
            }
        }

        // ✅ GRID CLICK AUTO FILL ✅🔥
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.CurrentRow != null)
            {
                txtSearch.Text = dataGridView1.CurrentRow.Cells["PID"].Value.ToString();
                txtRoom.Text = dataGridView1.CurrentRow.Cells["RoomNo"].Value.ToString();

                string dis = dataGridView1.CurrentRow.Cells["Discharge"].Value.ToString();

                if (dis == "Yes")
                    radioYes.Checked = true;
                else
                    radioNo.Checked = true;
            }
        }

        // ✅ BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Reception().Show();
        }

        // ✅ FIX DESIGNER ERROR
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // leave empty ✅
        }
    }
}