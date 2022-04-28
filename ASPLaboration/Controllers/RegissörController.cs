using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPLaboration;

namespace ASPLaboration.Controllers
{
    public class RegissörController : Controller
    {
        private FilmDBEntities1 db = new FilmDBEntities1();

        // GET: Regissör
        public ActionResult Index()
        {
            return View(db.Regissör.ToList());
        }

        // GET: Regissör/Details/5
        public ActionResult Detaljer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regissör regissör = db.Regissör.Find(id);
            if (regissör == null)
            {
                return HttpNotFound();
            }
            return View(regissör);
        }

        // GET: Regissör/Skapa
        public ActionResult SkapaNy()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Namn")] Regissör regissör)
        {
            if (ModelState.IsValid)
            {
                db.Regissör.Add(regissör);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regissör);
        }

        
        public ActionResult Redigera(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regissör regissör = db.Regissör.Find(id);
            if (regissör == null)
            {
                return HttpNotFound();
            }
            return View(regissör);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Namn")] Regissör regissör)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regissör).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regissör);
        }

        // GET: Regissör/Delete/5
        public ActionResult Radera(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regissör regissör = db.Regissör.Find(id);
            if (regissör == null)
            {
                return HttpNotFound();
            }
            return View(regissör);
        }

        // POST: Regissör/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regissör regissör = db.Regissör.Find(id);
            db.Regissör.Remove(regissör);
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
