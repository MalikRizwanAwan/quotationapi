using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODELS.Model;
using System.Web.Http.Cors;

namespace CustomerOrder.Controllers
{

    [RoutePrefix("api/Home")]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    
    }
}
