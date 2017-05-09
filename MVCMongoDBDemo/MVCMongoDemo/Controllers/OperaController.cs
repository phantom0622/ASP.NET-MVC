using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMongoDemo.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MVCMongoDemo.Controllers
{
    public class OperaController : Controller
    {

        private readonly OperaDB Context = new OperaDB();

        public ActionResult Index()
        {
            var op = Context.Datas.FindAll().SetSortOrder(SortBy<Opera>.Ascending(r => r.OperaID));
            return View(op);
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
                Context.Datas.Insert(op);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string Id)
        {
            var op = Context.Datas.FindOneById(new ObjectId(Id));
            return View(op);
        }

        [HttpPost]
        public ActionResult Edit(Opera op)
        {
            if (ModelState.IsValid)
            {
                Context.Datas.Save(op);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var rental = Context.Datas.FindOneById(new ObjectId(Id));
            return View(rental);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            var rental = Context.Datas.Remove(Query.EQ("_id", new ObjectId(Id)));
            return RedirectToAction("Index");
        }

	}
}