using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        [ValidateAntiForgeryToken]
        [HttpPost]
        public void AddSale(Guid BookID)
        {
            Sale s = new Sale()
            {
                DateOfSale = DateTime.Now,
                SaleID = Guid.NewGuid(),
                Buyer = Session["Logged"] as User
                
            };
        }
    }
}