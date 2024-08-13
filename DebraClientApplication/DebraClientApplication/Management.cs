using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraClientApplication
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            {
                string url = "https://localhost:7166/api/AddTicket";
                WebClient client = new WebClient();
                client.Headers["content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.DownloadString(url);
                dgvCommission.DataSource = null;
                dgvCommission.DataSource = (new JavaScriptSerializer()).
                    Deserialize<List<Ticket>>(json);
            }
        }

        private void dgvCommission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        class Ticket
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public decimal Price { get; set; }

            public bool IsSold { get; set; }

            public decimal Commission { get; set; }

            public DateTime? SaleDate { get; set; }


        }

        private void btnMDash_Click(object sender, EventArgs e)
        {
            Management_Dashboard management_Dashboard = new Management_Dashboard();
            management_Dashboard.Show();
            this.Hide();
        }

    }
    }
