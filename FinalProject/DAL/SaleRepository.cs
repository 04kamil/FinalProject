using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models;


namespace FinalProject.DAL
{
    public static class SaleRepository
    {
        public static void AddSale(Sale s)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Sales.Add(s);
                db.SaveChanges();
            }
        }
    }
}