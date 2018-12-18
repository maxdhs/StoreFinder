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
            List<Comment> foundComments = Comment.GetCommentsByLicense(id);
            Dispensary foundDispensary = Dispensary.FindByLicense(id);
            Dictionary<string, object> model = new Dictionary<string, object> {};
            model.Add("dispensary", foundDispensary);
            model.Add("comments", foundComments);
            return View(model);
        }

        [HttpPost("/dispensaries/searchbyname")]
        public ActionResult SearchName(string DispensaryName)
        {   
            Dispensary foundDispensary = Dispensary.FindByName(DispensaryName);
            return View("Show", foundDispensary);     
        }

        [HttpPost("/dispensaries/{license}/comments")]
        public ActionResult CreateComment(int license, string review, int rating)
        {
            Comment newComment = new Comment(review, rating, license);
            newComment.Save();
            List<Comment> foundComments = Comment.GetCommentsByLicense(license);
            Dispensary foundDispensary = Dispensary.FindByLicense(license);
            Dictionary<string, object> model = new Dictionary<string, object> {};
            model.Add("dispensary", foundDispensary);
            model.Add("comments", foundComments);
            return View("Show", model); 
        }
    }
}
