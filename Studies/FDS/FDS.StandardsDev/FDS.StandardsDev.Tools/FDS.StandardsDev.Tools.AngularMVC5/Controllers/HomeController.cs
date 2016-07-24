using FDS.StandardsDev.Tools.AngularMVC5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDS.StandardsDev.Tools.AngularMVC5.Controllers
{
    [RoutePrefix("")]
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult Configuration()
        {
            return View();
        }
    }
}