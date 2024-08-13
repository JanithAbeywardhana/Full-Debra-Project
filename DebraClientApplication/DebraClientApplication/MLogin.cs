using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraClientApplication
{
    public partial class MLogin : Form
    {
        public MLogin()
        {
            InitializeComponent();
        }

        private void btnMLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtMUserName.Text;
            pass = txtMPassword.Text;
            if (user == "admin" && pass == "admin")
            {
                MessageBox.Show("Successful");
                Management_Dashboard management_Dashboard = new Management_Dashboard();
                management_Dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Privacy privacy = new Privacy();
            privacy.Show();
            this.Hide();
        }
    }
}
