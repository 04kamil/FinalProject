using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public class BookRepository
    {
        public static List<Book> GetList()
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                return db.Books.ToList();
            }
        }

        public static Book Get(Guid id)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                var user = db.Books.SingleOrDefault(m => m.BookId == id);
                return user;
            }
        }

        public static void Create(Book a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Books.Add(a);
                db.SaveChanges();
            }
        }

        public static void Update(Book a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(Book a)
        {
            using (FinalProjectContext db = new FinalProjectContext())
            {
                db.Books.Remove(a);
                db.SaveChanges();
            }
        }
    }
}