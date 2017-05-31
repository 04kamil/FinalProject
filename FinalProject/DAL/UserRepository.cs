using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public class UserRepository
    {
        public static void Create(User a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Users.Add(a);
                db.SaveChanges();
            }
        }
    }
}