using DebraEventWebClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace DebraEventWebClient.Pages
{
    public class ViewCommissionModel : PageModel
    {

        public List<TicketCommission> ticketCommissions = new List<TicketCommission>();
        public async Task<IActionResult> OnGet()
        {
            String url = "https://localhost:7166/api/AddTicket";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    ticketCommissions = await response.Content.ReadFromJsonAsync<List<TicketCommission>>();

                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                return Page();
            }
        }
    }
}
