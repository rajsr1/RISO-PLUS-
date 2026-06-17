using System;
using System.Windows.Forms;

namespace RISO
{
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {

        }

        // Manage Users
        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            Manage_Users mu = new Manage_Users();
            mu.Show();

            this.Hide();
        }

        // Manage Doctors
        private void btnManageDoctors_Click(object sender, EventArgs e)
        {
            Manage_Doctors md = new Manage_Doctors();
            md.Show();

            this.Hide();
        }

        // Manage Departments
        private void btnManageDepartments_Click(object sender, EventArgs e)
        {
            Manage_Departments mp = new Manage_Departments();
            mp.Show();

            this.Hide();
        }

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();

            this.Close();
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Rreceptionist");
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Doctor");
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Rreceptionist");
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in Admin panel");
        }
    }
}