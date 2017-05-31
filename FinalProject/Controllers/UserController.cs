using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace FinalProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User u)
        {
            if (ModelState.IsValid)             //pierwsza sprawdzenie czy jest user
            {
                u.Active = false;
                u.AccountType = 0;
                u.UserID = Guid.NewGuid();
                

                Guid g = Guid.NewGuid();
                Registration r = new Registration()
                {
                    ConfirmRegistrationCode = g.ToString(),
                    EmailSend = DateTime.Now,
                    EmailExpired = DateTime.Now.AddDays(2),
                    Uzk = u,
                };
                RegistrationRepository.Create(r);           //czemu tu sprawdza
                UserRepository.Create(u);                   //tu też!!!???
                SendMail(u.Email.ToString(),g.ToString());
                return RedirectToAction("Registration");
            }

            return View(u);
        }

        public ActionResult Confirm(string s)
        {
            string text = HttpContext.Request.Url.PathAndQuery;
            var lst = text.Split('/');
            var r = RegistrationRepository.FindByConfirmationCode(new Guid(lst.Last()));

            if (r == null || r.EmailExpired < DateTime.Now)
            {
                ViewBag.Result = "Cos poszlo nie tak";
            }
            else
            {
                ViewBag.Result = "rejestracja udana";
                User u = UserRepository.Read(new Guid(RegistrationRepository.GetUserID(lst.Last())));
                UserRepository.ActiveAccount(u);

            }
            return View();
        }

        public static void SendMail(string userEmail, string content)
        {

            var fromAdress = new MailAddress("projectappweb@gmail.com", "Ebook Shop App");
            var toAdress = new MailAddress(userEmail);
            //tu wpisac poprawne haslo
            string pass = "Alfa1234";


            //"localhost:51740/User/Confirm/"

            MailMessage mail = new MailMessage("projectappweb@gmail.com", userEmail);
            mail.Subject = "witaj";
            mail.Body = String.Format(
                "<h3>Welcome to ProjectWebApp</h3>\n"
                + "Please click here to active account\n"
                + @"<a href=""//localhost:51740/User/Confirm/{0}""/>Click</a>", content
                );
            mail.IsBodyHtml = true;



            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromAdress.Address, pass);


            client.Send(mail);
        }



        [HttpPost]
        public ActionResult Login(string Login_, string Password_)
        {
            User user = UserRepository.FindByLoginAndPassword(Login_, Password_);
            if (user == null)
            {
                return RedirectToAction("WrongLoginOrPassword", "Error", new { area = "" });
            }
            else
            {
                Session["Logged"] = user;
                return Redirect("Index");
            }

        }

        public ActionResult Logout()
        {
            Session["Logged"] = null;
            return Redirect("Index");
        }





    }
}