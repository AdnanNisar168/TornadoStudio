using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TornadoStudio.Models;

namespace TornadoStudio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[Authorize]
        [HttpPost]
        public ActionResult Login(Login model)
        {
            //actionResultJson.data = new general_result()
            return Json(model);
        }
    }
}