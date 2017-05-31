using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Authors.Add(new Author()
                {
                    Name = "platon",
                    DateOfBirth = "123",
                    DateOfDeath = "ops",
                    Descryption = "jakis opis"
                    
                });
            }
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}