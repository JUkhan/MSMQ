using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAce.Models.Agent;

namespace WebAce.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult RunProcess()
        {
            try
            {
                AgentClientManager.RegisterAgent();

                StateManager.SetStates(101);
                StateManager.Run(101);

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