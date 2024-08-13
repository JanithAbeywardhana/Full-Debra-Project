using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraClientApplication
{
    public partial class Manage_Partner : Form
    {
        int id = 0;
        public Manage_Partner()
        {
            InitializeComponent();
        }

        private void Manage_Partner_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7166/api/PartnerRegister";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvPartner.DataSource = null;
            dgvPartner.DataSource = (new JavaScriptSerializer()).
                Deserialize<List<Partner>>(json);
        }


        class Partner
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            //public string Password { get; set; } = string.Empty;
        }

        private void dgvPartner_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtPID.Text = dgvPartner.Rows[row].Cells[1].Value.ToString();
                txtPName.Text = dgvPartner.Rows[row].Cells[2].Value.ToString();
                txtPEmail.Text = dgvPartner.Rows[row].Cells[3].Value.ToString();
                //txtPPassword.Text = dgvPartner.Rows[row].Cells[4].Value.ToString();
                id = Convert.ToInt32(dgvPartner.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void btnRPartner_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7166/api/PartnerRegister/" + id;
            HttpClient httpClient = new HttpClient();
            DialogResult result = MessageBox.Show("Are you sure you want to remove this partner?","Delete Partner",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var res =  httpClient.DeleteAsync(url).Result;
                if(res.IsSuccessStatusCode)
                {
                    LoadData();
                    txtPID.Clear();
                    txtPName.Clear();
                    txtPEmail.Clear();
                }
            }
        }

        private void btnPBack_Click(object sender, EventArgs e)
        {
            Management_Dashboard management_Dashboard = new Management_Dashboard();
            management_Dashboard.Show();
            this.Hide();
        }
    }
}
