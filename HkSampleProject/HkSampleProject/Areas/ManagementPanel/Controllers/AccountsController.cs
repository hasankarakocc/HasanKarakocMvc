using HkSampleProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HkSampleProject.Areas.ManagementPanel.Controllers
{
    public class AccountsController : Controller
    {
         SampleContext db = new SampleContext();
        // GET: ManagementPanel/Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Users user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.LoginError = "Kulanıcı adı veya şifre yanlış";
                return View();
            }
            Session["PanelSession"] = user.Email;
            return RedirectToAction("Index", "Panel");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}