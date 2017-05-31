using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public static class LogRepository
    {
        public static void Create(Log r)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Logs.Add(r);
                db.SaveChanges();
            }
        }
    }
}