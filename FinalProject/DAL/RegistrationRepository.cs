using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public static class RegistrationRepository
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


                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
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