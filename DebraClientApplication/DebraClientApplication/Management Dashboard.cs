using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraClientApplication
{
    public partial class Management_Dashboard : Form
    {
        public Management_Dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Management management = new Management();
            management.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewEvents viewEvents = new ViewEvents();   
            viewEvents.Show();
            this.Hide();
        }

        private void btnMLogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMPartner_Click(object sender, EventArgs e)
        {
            Manage_Partner managePartner = new Manage_Partner();
            managePartner.Show();
            this.Hide();
        }
    }
}
