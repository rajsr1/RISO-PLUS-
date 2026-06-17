using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RISO
{
    public partial class Doc_Dashboard : Form
    {
        public Doc_Dashboard()
        {
            InitializeComponent();
        }

        private void Doc_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnPatientAppointmentPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Portal patient_Portal = new Patient_Portal();
            patient_Portal.Show();
        }

        private void btnPatientDetailsPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Card patient_Card = new Patient_Card();
            patient_Card.Show();
        }

        private void btnPrescriptionPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Prescription_Panel prescription_Panel = new Prescription_Panel();
            prescription_Panel.Show();
        }

        private void btnMedicalHistoryPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medical_Profile medical_Profile = new Medical_Profile();
            medical_Profile.Show();
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Admin");
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Reception");
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Billing");
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already log in as Doctor");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();

            this.Close();
        }
    }
}
