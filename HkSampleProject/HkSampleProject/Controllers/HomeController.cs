using HkSampleProject.Models.Entities;
using HkSampleProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HkSampleProject.Controllers
{
    public class HomeController : Controller
    {
        SampleContext db = new SampleContext();
        public ActionResult Index()
        {

            var model = new IndexViewModel();

            model.Abouts = db.Abouts.FirstOrDefault(a => a.IsActive);
            model.Clients = db.Clients.Where(x => x.IsActive).ToList();
            model.Portfolios = db.Portfolios.Where(x => x.IsActive).ToList();
            model.Pricings = db.Pricings.Where(x => x.IsActive).ToList();
            model.PortfolioCategories = db.PortfolioCategories.Where(x => x.IsActive).ToList();
            model.ContactSets = db.ContactSets.FirstOrDefault(a => a.IsActive);

            ViewBag.Contacts = new SelectList(db.OtherContacts, "Icon", "Value");
            ContactSets set = db.ContactSets.FirstOrDefault(a => a.IsActive);
            ViewBag.Phone = set.Phone;
            ViewBag.Email = set.Email;
            ViewBag.Adress = set.Adress;
            return View(model);
        }

        public ActionResult PortfolioDetails()
        {
            return View();
        }
    }
}