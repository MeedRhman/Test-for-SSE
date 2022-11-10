using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Repostories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepo _custRepo;
        private readonly IWebHostEnvironment _webHost;

        public CustomerController(CustomerRepo CustRepo, IWebHostEnvironment webHost)
        {
            _custRepo = CustRepo;
            _webHost = webHost;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            List<Customer> Customers;
            Customers = _custRepo.GetAll().ToList();
            return Customers;
        }

        [HttpPost("newcust")]
        public void Post([FromForm] Customer customer)
        {
            var pathImage = Path.Combine(_webHost.WebRootPath, "Images", customer.ProfilePhoto.FileName);
            var streamImage = new FileStream(pathImage, FileMode.Append);
            customer.ProfilePhoto.CopyTo(streamImage);
            var newCustomer = new Customer
            {

                CustomerName = customer.CustomerName,
                FatherName = customer.FatherName,
                MotherName = customer.MotherName,
                PhotoUrl = pathImage,
                CustomerAddresses = customer.CustomerAddresses,
                CountryId = customer.CountryId,
            };


            _custRepo.Add(newCustomer);
        }

       

       

    }
}
