using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public class RegistrationRepository
    {
        public static Registration FindByConfirmationCode(Guid id)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                Registration r = (from p in db.Registrations where p.ConfirmRegistrationCode == id.ToString() select p).SingleOrDefault();
                return r;
            }
        }

        public static string GetUserID(string str)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                var g = (from p in db.Registrations where p.ConfirmRegistrationCode.ToString() == str select p.Uzk.UserID.ToString()).SingleOrDefault();
                return g;
            }
        }

        public static void Create(Registration r)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Registrations.Add(r);
                db.SaveChanges();
            }
        }

        public static Registration Read(Guid id)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                Registration r = db.Registrations.Find(id);
                return r;
            }
        }
    }
}