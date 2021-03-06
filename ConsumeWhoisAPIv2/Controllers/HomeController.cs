﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsumeWhoisAPIv2.Models;
using ConsumeWhoisAPIv2.Client;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace ConsumeWhoisAPIv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DomainContext _db;

        public HomeController(DomainContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> History()
        {
            return View(await _db.Domains.ToListAsync());
        }

        [HttpPost]
        public ActionResult DomainSearch(string domain)
        {
            if (_db.Domains.FirstOrDefault(d => d.Name == domain && d.RequestTime.AddMinutes(2) > DateTime.UtcNow) != null)
            {
                Console.WriteLine("Db Accessed");
                var domainAlreadyinDb = _db.Domains.FromCache().FirstOrDefault(d => d.Name == domain);
                return View("Index", domainAlreadyinDb);
            }
            else
            {
                Console.WriteLine("Api Accessed");
                var domainResponse = new RequestApiClient().DomainSearch(domain);

                if(domainResponse.Registered)
                {
                    _db.Domains.Add(domainResponse);
                    _db.SaveChanges();
                }
        
                return View("Index", domainResponse);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
