using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Weed.Models;
using System;

namespace Weed.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {   
            return View();
        }
    }
}
