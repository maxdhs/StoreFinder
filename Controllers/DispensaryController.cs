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
            List<Dispensary> allDispensaries = Dispensary.GetAll();
            return View(allDispensaries);
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
