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
    public partial class Reception : Form
    {
        public Reception()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblPatientManagmentPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnPatientAdmissionPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Admission_Panel patient_Admission_Panel = new Patient_Admission_Panel();
            patient_Admission_Panel.Show();
        }

        private void btnPatientListPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_List_Panel patient_List_Panel = new Patient_List_Panel();
            patient_List_Panel.Show();
        }

        private void btnAppointmentPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointment_Panel appointment_Panel = new Appointment_Panel();
            appointment_Panel.Show();
        }

        private void btnRoomPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Room_Panel room_Panel = new Room_Panel();
            room_Panel.Show();
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Admin");
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in Rreceptionist");
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Doctor");
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Billing");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();

            this.Close();
        }
    }
}
