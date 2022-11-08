using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class CustomerController : Controller
    {
       

       
        private readonly IConfiguration _configuration;
        HttpClientHandler _clientHandler = new HttpClientHandler();
        HttpClient client = new HttpClient();

        public CustomerController( IConfiguration configuration)
        {

            _configuration = configuration;

            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }
        

      
        public IActionResult Index()
        {
            Customer customer = new Customer();
            customer.CustomerAddresses.Add(new CustomerAddress() { CustomerAddressId = 1});
            var countries = GetCountryAsync();
            ViewData["Countries"] = new SelectList((System.Collections.IEnumerable)countries, "CountoryId", "CountryName");
            return View("Create", customer);
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            string data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("https://localhost:44327/api/Customer/newcust", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IEnumerable<Country>> GetCountryAsync()
        {
            var _countries = new List<Country>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44327/api/country"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    _countries = JsonConvert.DeserializeObject<List<Country>>(apiresponse);
                }
            }
            return _countries;
        }
    }
}
