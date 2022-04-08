using HkSampleProject.Areas.ManagementPanel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HkSampleProject.Areas.ManagementPanel.Controllers
{
    [Auth]
    public class PanelController : Controller
    {
        // GET: ManagementPanel/Panel
        public ActionResult Index()
        {
            return View();
        }
    }
}