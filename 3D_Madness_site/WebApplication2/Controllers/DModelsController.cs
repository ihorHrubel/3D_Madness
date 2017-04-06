using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DModels
        public ActionResult Index()
        {
            return View(db.DModels.ToList());
        }

        // GET: DModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DModel dModel = db.DModels.Find(id);
            if (dModel == null)
            {
                return HttpNotFound();
            }
            return View(dModel);
        }

       


        // GET: DModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Name,Description,Weight,Version,Color,Style")] DModel dModel)
        {
            if (ModelState.IsValid)
            {
                db.DModels.Add(dModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dModel);
        }

        // GET: DModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DModel dModel = db.DModels.Find(id);
            if (dModel == null)
            {
                return HttpNotFound();
            }
            return View(dModel);
        }

        // POST: DModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Name,Description,Weight,Version,Color,Style")] DModel dModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dModel);
        }

        // GET: DModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DModel dModel = db.DModels.Find(id);
            if (dModel == null)
            {
                return HttpNotFound();
            }
            return View(dModel);
        }

        // POST: DModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DModel dModel = db.DModels.Find(id);
            db.DModels.Remove(dModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
