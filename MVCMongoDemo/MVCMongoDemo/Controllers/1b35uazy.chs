using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMongoDemo.Models;

namespace MVCMongoDemo.Controllers
{
    public class OperaController : Controller
    {
        //
        // GET: /Opera/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

	}
}