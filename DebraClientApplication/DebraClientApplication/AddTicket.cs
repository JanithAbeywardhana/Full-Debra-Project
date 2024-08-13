using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraClientApplication
{
    public partial class AddTicket : Form
    {

        public int EID;

        public AddTicket(int idB)
        {
            InitializeComponent();
            EID = idB;

            txtTEventID.Text = EID.ToString();
            LoadData();


            
        }

        int id = 0;
        public AddTicket()
        {
            InitializeComponent();
        }

        private void AddTicket_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7166/api/AddTicket";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            dgvSellTicket.DataSource = null;
            dgvSellTicket.DataSource = (new JavaScriptSerializer()).
                Deserialize<List<Ticket>>(json);

        }

        private void btnTAdd_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7166/api/AddTicket";
            HttpClient httpClient = new HttpClient();
            Ticket ticket = new Ticket();
            ticket.Title = txtTTitle.Text;
            ticket.Price = Convert.ToInt32(txtTPrice.Text);
            ticket.IsSold = true;
            ticket.IsSold = false;

            ticket.SaleDate = DateTime.Now;
            ticket.EventId = EID;
            string data = (new JavaScriptSerializer()).Serialize(ticket);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpClient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Ticket Added");
                LoadData();
            }
            else
                MessageBox.Show("Failed to Added");


        }

        class Ticket
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public decimal Price { get; set; }

            public bool IsSold { get; set; }

            //public decimal Commission { get; set; }

            public DateTime? SaleDate { get; set; }

            public int EventId { get; set; }


        }

        private void dgvSTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTUpdate_Click(object sender, EventArgs e)
        {


        }

        private void btnTSell_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTSell_Click_1(object sender, EventArgs e)
        {
            string url = "https://localhost:7166/api/AddTicket/"+id;
            HttpClient httpclient = new HttpClient();
            Ticket ticket = new Ticket();
            ticket.Id = id;
            ticket.IsSold = true;
            string data = (new JavaScriptSerializer()).Serialize(ticket);
            var connect = new StringContent(data, UnicodeEncoding.UTF8,"application/json");
            var res = httpclient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Sell Successfully");
                LoadData();
            }
            else
                MessageBox.Show("Faild to sold Out");

        }

        private void btnTBack_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        private void txtTEventID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSellTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col == 0)
            {
               
                txtTID.Text = dgvSellTicket.Rows[row].Cells[1].Value.ToString();
                txtTTitle.Text = dgvSellTicket.Rows[row].Cells[2].Value.ToString();
                txtTIsSold.Text = dgvSellTicket.Rows[row].Cells[3].Value.ToString();
                txtTPrice.Text = dgvSellTicket.Rows[row].Cells[4].Value.ToString();
                txtTDate.Text = dgvSellTicket.Rows[row].Cells[5].Value.ToString();
                txtTEventID.Text = dgvSellTicket.Rows[row].Cells[6].Value.ToString();

                id = Convert.ToInt32(dgvSellTicket.Rows[row].Cells[1].Value.ToString());
            }
        }

        private void btnTUpdate_Click_1(object sender, EventArgs e)
        {
            string url = "https://localhost:7166/api/AddTicket/"+id;
            HttpClient httpClient = new HttpClient();   
            Ticket ticket = new Ticket();
            ticket.Id = id;
            ticket.Title = txtTID.Text;
            ticket.Price = Convert.ToInt32(txtTPrice.Text);
            ticket.SaleDate = DateTime.Now;
            string data = (new JavaScriptSerializer()).Serialize(ticket);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpClient.PutAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Ticket Updated");
                LoadData();

            }
            else
                MessageBox.Show("Fail to update event");
        }
    }
}
