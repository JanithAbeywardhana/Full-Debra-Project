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
    public partial class ViewEvents : Form
    {
        public ViewEvents()
        {
            InitializeComponent();
        }

        private void btnMBack_Click(object sender, EventArgs e)
        {
            Management_Dashboard management_Dashboard = new Management_Dashboard();
            management_Dashboard.Show();
            this.Hide();
        }

        private void dgvMEvent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ViewEvents_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7166/api/AddEvent ";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvMEvent.DataSource = null;
            dgvMEvent.DataSource = (new JavaScriptSerializer()).
                Deserialize<List<AddEvent>>(json);
        }


        class AddEvent
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public string Location { get; set; }

            public DateTime Date { get; set; }


        }
    }
}
