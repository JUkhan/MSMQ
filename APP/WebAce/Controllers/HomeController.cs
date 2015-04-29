using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAce.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult RunProcess()
        {
            try
            {
                ServiceRef.Service1Client client = new ServiceRef.Service1Client();
                client.GetData(100);
                client.Close();
                Agent2.Service1Client agent2 = new Agent2.Service1Client();
                agent2.GetData(2000);
                agent2.Close();
                return Json(new { msg = "Running" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
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
    }
}