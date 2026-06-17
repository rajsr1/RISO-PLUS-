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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMedicineManagementPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicine_Management_panel medicine_Management_Panel = new Medicine_Management_panel();
            medicine_Management_Panel.Show();
        }

        

        private void btnBillingPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing_Panel billing_Panel = new Billing_Panel();
            billing_Panel.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment___Invoice_Panel payment___Invoice_Panel = new Payment___Invoice_Panel();
            payment___Invoice_Panel.Show();
        }

        private void btnMedicineStokePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicine_Stoke_Panel medicine_Stoke_Panel = new Medicine_Stoke_Panel();
            medicine_Stoke_Panel.Show();
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Admin");
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Reception");
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please log in as Doctor");
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in Billing");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();

            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
