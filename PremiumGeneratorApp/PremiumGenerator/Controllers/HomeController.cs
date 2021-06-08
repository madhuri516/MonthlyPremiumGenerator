using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumGenerator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace PremiumGenerator.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private IPremiumCalculator _premiumCalculator;
        

        public HomeController(IPremiumCalculator premiumCalculator)
        {
            _premiumCalculator = premiumCalculator;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PremiumGenerator()
        {
            Occupation occupation = new Occupation();

            MemberDetails memberDetails = new MemberDetails();
            memberDetails.OccupationType = occupation.OccupationType.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.ToString(),
                        Value = a.ToString(),
                        Selected = false
                    };
                });


            return View(memberDetails);
        }

        [HttpPost]
        public IActionResult PremiumGenerator(MemberDetails memberDetails)
        {
            double deathCoverAmount = memberDetails.DeathCoverAmount;
            int age = memberDetails.Age;
            string occupation = memberDetails.SelectedItem;
            double occupationRatingFactor = memberDetails.occupation.GetOccupationRatingFactor(occupation);
            double premiumAmount = _premiumCalculator.CalculateMonthlyPremiumAmount(deathCoverAmount, occupationRatingFactor, age);
            memberDetails.PremiumAmount = premiumAmount;

            //ViewBag.Message = "Your monthly premium amount is: "+premiumAmount;

            //ViewData["premiumamount"] = premiumAmount;
            return View(memberDetails);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
