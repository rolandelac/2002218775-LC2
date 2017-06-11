using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2002218775_ENT;
using _2002218775_PER;

namespace _2002218775_MVC.Controllers
{
    public class AsientoesController : Controller
    {
        private _2002218775DbContext db = new _2002218775DbContext();

        // GET: Asientoes
        public ActionResult Index()
        {
            var asientos = db.Asientos.Include(a => a.Carro);
            return View(asientos.ToList());
        }

        // GET: Asientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // GET: Asientoes/Create
        public ActionResult Create()
        {
            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor");
            return View();
        }

        // POST: Asientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsientoId,NumSerie,CarroId")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Asientos.Add(asiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", asiento.CarroId);
            return View(asiento);
        }

        // GET: Asientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", asiento.CarroId);
            return View(asiento);
        }

        // POST: Asientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsientoId,NumSerie,CarroId")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", asiento.CarroId);
            return View(asiento);
        }

        // GET: Asientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // POST: Asientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            db.Asientos.Remove(asiento);
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
