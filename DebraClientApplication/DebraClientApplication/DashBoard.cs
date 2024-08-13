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
    public partial class DashBoard : Form
    {
        public int PID;
        public DashBoard(int id)
        {
            InitializeComponent();
            PID = id;
        }
        public DashBoard()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateEve_Click(object sender, EventArgs e)
        {
            Event @event = new Event(PID);
            @event.Show();
            this.Hide();
        }

        private void btnSetTick_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Sell Ticket?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Add Event to continue.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Event @event2 = new Event(PID);
                @event2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You chose not to continue.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            
        }
    }
}
