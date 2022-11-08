using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Components
{
    public class CustomerViewComponent :ViewComponent
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public CustomerViewComponent()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var _customers = new List<Customer>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44327/api/customer"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    _customers = JsonConvert.DeserializeObject<List<Customer>>(apiresponse);
                }
            }
            return  View(_customers);
        }
    }
}
