using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public static class UserRepository
    {
        public static void Create(User a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Users.Add(a);
                db.SaveChanges();
            }
        }

        public static User Read(Guid id)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                User a = db.Users.Find(id);
                return a;
            }
        }

        public static User FindByLoginAndPassword(string login_, string password_)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                User u = (from p in db.Users where p.Login == login_ && p.Password == password_ select p).FirstOrDefault();
                return u;
            }
        }

        public static void ActiveAccount(User u)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                User user = db.Users.Find(u.UserID);
                if (u != null)
                {
                    user.Active = true;
                    //testowanie co mu sie nie podoba
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


                }
            }
        }

        public static User IsLoginAvailable(string name_)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                var user = (from p in db.Users where p.Login == name_ select p).FirstOrDefault();

                return user;

            }
        }

        public static User IsmailAvailable(string mail_)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                var user = (from p in db.Users where p.Login == mail_ select p).FirstOrDefault();

                return user;

            }
        }

    }
}