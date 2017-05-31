using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public static class AuthorRepository
    {
        public static List<Author> GetList()
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                return db.Authors.ToList();
            }
        }

        public static Author Get(Guid id)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                var user = db.Authors.SingleOrDefault(m => m.AuthorID == id);
                return user;
            }
        }

        public static void Create(Author a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Authors.Add(a);
                db.SaveChanges();
            }
        }

        public static void Update(Author a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(Author a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Authors.Remove(a);
                db.SaveChanges();
            }
        }

    }
}