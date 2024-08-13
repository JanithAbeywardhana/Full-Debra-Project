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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void managementLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MLogin login = new MLogin();
            login.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Privacy privacy = new Privacy();
            privacy.Show();
            this.Hide();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            Privacy privacy = new Privacy();
            privacy.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
