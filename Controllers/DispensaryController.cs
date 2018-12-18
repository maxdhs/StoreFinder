using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Weed.Models;

namespace Weed.Controllers
{
    public class DispensaryController : Controller
    {
        [HttpGet("/dispensaries")]
        public ActionResult Index()
        {
            string cityName ="Seattle";
            Dictionary<string,object> model = new Dictionary<string,object>{};
            List<Dispensary> allDispensaries = Dispensary.GetAll();
            List<Dispensary> allAddresses = Dispensary.GetAddresses(cityName);
            model.Add("dispensaries", allDispensaries);
            model.Add("addresses", allAddresses);
            return View(model);
        }

        [HttpGet("/dispensaries/{id}")]
        public ActionResult Show(int id)
        {
            Dispensary foundDispensary = Dispensary.FindByLicense(id);
            return View(foundDispensary);
        }

        [HttpPost("/dispensaries/searchbyname")]
        public ActionResult SearchName(string DispensaryName)
        {  Dispensary foundDispensary = Dispensary.FindByName(DispensaryName);
           return View("Show", foundDispensary);     
        }
    }
}
