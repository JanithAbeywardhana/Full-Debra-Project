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

using Nancy.Json;

namespace DebraClientApplication
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string url = "https://localhost:7166/api/PartnerRegister ";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            String json = client.DownloadString(url);

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7166/api/PartnerRegister";
            HttpClient httpClient = new HttpClient();
            PartnerRegister partnerRegister = new PartnerRegister();
            partnerRegister.Name = txtName.Text;
            partnerRegister.Email = txtEmail.Text;
            partnerRegister.Password = txtPassword.Text;
            string data = (new JavaScriptSerializer()).Serialize(partnerRegister);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpClient.PostAsync(url, connect).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Registerd Succsessfuly! Login via the dashboard to use Debra Events ");
                LoadData();

                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Faild to Register! Please Try Again");


        }

        class PartnerRegister
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Email { get; set; }

            public string Password { get; set; } = string.Empty;
        }

        private void Register_Load_1(object sender, EventArgs e)
        {

        }
    }
}

