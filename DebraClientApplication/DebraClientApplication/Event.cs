using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DebraClientApplication.Login;

namespace DebraClientApplication
{
    public partial class Event : Form
    {
        int id = 0;
        public List<Event> events = new List<Event>();
        public Event(int idA)
        {
            InitializeComponent();
            id = idA;

            txtPartnerID.Text = idA.ToString();
            loadEvents(id);
        }

        public void loadEvents( int id)
        {
            string url = "https://localhost:7166/api/AddEvent/partner/" + id;
            using (HttpClient httpClient = new HttpClient())
            {
                var responce = httpClient.GetStringAsync(url).Result;
                if(!string.IsNullOrEmpty(responce))
                {
                    var events = new JavaScriptSerializer().Deserialize<List<AddEvent>>(responce);
                    dgvEvents.DataSource = events;
                }
                else
                {
                    dgvEvents.DataSource= null;
                }
            }

        }

        private void Event_Load(object sender, EventArgs e)
        {
            LoadData(id);
        }

        private void LoadData(int partnerId)
        {
            string url = "https://localhost:7166/api/AddEvent";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvEvents.DataSource = null;
            dgvEvents.DataSource = (new JavaScriptSerializer()).
                Deserialize<List<AddEvent>>(json);
        }

        private void btnEAdd_Click(object sender, EventArgs e)
        {

            string url = "https://localhost:7166/api/AddEvent?partnerId="+id;
            HttpClient httpClient = new HttpClient();
            AddEvent addEvent = new AddEvent();

            addEvent.Name = txtEName.Text;
            addEvent.Description = txtEDes.Text;
            addEvent.Location = txtELoc.Text;
            addEvent.Date = DateTime.Now;
            //addEvent.PartnerId = id;
            string data = (new JavaScriptSerializer()).Serialize(addEvent);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpClient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Event Added");
                LoadData(id);
            }
            else
                MessageBox.Show("Failed to Added");
        }

        private void btnEUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnEDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        class AddEvent
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public string Location { get; set; }

            public DateTime Date { get; set; }

            public int PartnerId { get; set; }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
            //SearchEvents searchEvents = new SearchEvents();
            //searchEvents.Show();
            //his.Hide();
        //}

        private void Event_Load_1(object sender, EventArgs e)
        {
            txtPartnerID.Text = ((DashBoard)Application.OpenForms["DashBoard"]).PID.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
         {
            if (!string.IsNullOrEmpty(txtEID.Text))
            {
                int eventId = int.Parse(txtEID.Text);
                AddTicket addTicket = new AddTicket(eventId);
                addTicket.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("please select an event first.");
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DashBoard dashBoard1 = new DashBoard();
            dashBoard1.Show();
            this.Hide();
        }

        private void dgvEvents_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
                txtEID.Text = dgvEvents.Rows[row].Cells[1].Value.ToString();
                txtEName.Text = dgvEvents.Rows[row].Cells[2].Value.ToString();
                txtEDes.Text = dgvEvents.Rows[row].Cells[3].Value.ToString();
                txtELoc.Text = dgvEvents.Rows[row].Cells[4].Value.ToString();
                txtEDate.Text = dgvEvents.Rows[row].Cells[5].Value.ToString();
                txtPartnerID.Text = dgvEvents.Rows[row].Cells[6].Value.ToString();
                id = Convert.ToInt32(dgvEvents.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void btnEDelete_Click_1(object sender, EventArgs e)
        {
            string url = "https://localhost:7166/api/AddEvent/"+id;
            HttpClient httpclient = new HttpClient();
            DialogResult result = MessageBox.Show("Are you sure you want to delete", "Delete Product",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var res= httpclient.DeleteAsync(url).Result;
                if (res.IsSuccessStatusCode)
                {
                    LoadData(id);
                    txtEID.Clear();
                    txtEName.Clear();
                    txtELoc.Clear();
                    txtEDes.Clear();
                    txtEDate.Clear();
                    txtPartnerID.Clear();
                }
            }
        }

        private void btnEUpdate_Click_1(object sender, EventArgs e)
        {
        }
    }
}
