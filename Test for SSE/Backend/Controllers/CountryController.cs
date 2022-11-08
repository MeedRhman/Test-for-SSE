﻿using Backend.Models;
using Backend.Repostories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountoryRepo _countryRepo;
        private readonly IWebHostEnvironment _webHost;

        public CountryController(CountoryRepo countryRepo, IWebHostEnvironment webHost)
        {
            _countryRepo = countryRepo;
            _webHost = webHost;
        }

        public IEnumerable<Country> Get()
        {
            List<Country> countries;
            countries = _countryRepo.GetAll().ToList();
            return countries;
        }
    }
}
