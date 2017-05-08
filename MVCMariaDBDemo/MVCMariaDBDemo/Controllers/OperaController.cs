using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMariaDBDemo.Models;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MVCMariaDBDemo.Controllers
{
    public class OperaController : Controller
    {
        private readonly MySqlContext context = new MySqlContext();
        //
        // GET: /Opera/
        public ActionResult Index()
        {
           
            return View(context.GetOperas());
        }


        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Opera op)
        {
            if (ModelState.IsValid)
            {
                context.InsertOperas(op);
                return RedirectToAction("Index");
            }
            return View(op);
        }

        public ActionResult Edit(string id)
        {
            var op = context.SelectOperaItem(id);
            return View(op);
        }
        [HttpPost]
        public ActionResult Edit(Opera op)
        {
            if (ModelState.IsValid)
            {
                context.UpdateOpera(op);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            var op = context.SelectOperaItem(id);
            return View(op);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            context.DeleteOpera(id);
            return RedirectToAction("Index");
        }
        
	}
}