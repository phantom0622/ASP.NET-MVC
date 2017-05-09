using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSQLServerDemo.DAL;
using MVCSQLServerDemo.Models;
using System.Data.Entity;

namespace MVCSQLServerDemo.Controllers
{
    public class OperaController : Controller
    {
        private OperaContext context = new OperaContext();

        // GET: Opera
        public ActionResult Index()
        {
            return View(context.Operas.ToList());
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
                context.Operas.Add(op);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(op);
        }

        public ActionResult Edit(int? id)
        {
            Opera o = context.Operas.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }
        [HttpPost]
        public ActionResult Edit(Opera op)
        {
            if (ModelState.IsValid)
            {
                context.Entry(op).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(op);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Opera o = context.Operas.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera o = context.Operas.Find(id);
            context.Operas.Remove(o);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}