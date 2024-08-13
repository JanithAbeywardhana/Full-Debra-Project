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
    public partial class Login : Form
    {
        int id = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadData()
        {
            string url = " https://localhost:7166/api/PartnerRegister/login";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string url = " https://localhost:7166/api/PartnerRegister/login";
            HttpClient httpClient = new HttpClient();
            PartnerLogin partnerLogin = new PartnerLogin();
            partnerLogin.Email = txtMail.Text;
            partnerLogin.Password = txtPwd.Text;
            string data = (new JavaScriptSerializer()).Serialize(partnerLogin);
            var connect = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = httpClient.PostAsync(url, connect).Result;

            if (res.IsSuccessStatusCode)
            {
                var responseContent = res.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                var loginResponse = jsSerializer.Deserialize<LoginResponse>(responseContent);
                int id = loginResponse.id;
                string eventurl = "https://localhost:7166/api/AddEvent/partner/" + id;
                HttpClient httpClient1 = new HttpClient();
                
               

                DashBoard dashBoard = new DashBoard(id);
                dashBoard.PID = id;
                dashBoard.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Login Faild! Please Try Again");
        }

        public class PartnerLogin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }

        public class LoginResponse
        {
            public int id { get; set; }
            
        }
    }
}

