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
    public class LlantasController : Controller
    {
        private _2002218775DbContext db = new _2002218775DbContext();

        // GET: Llantas
        public ActionResult Index()
        {
            var llantas = db.Llantas.Include(l => l.Carro);
            return View(llantas.ToList());
        }

        // GET: Llantas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llanta llanta = db.Llantas.Find(id);
            if (llanta == null)
            {
                return HttpNotFound();
            }
            return View(llanta);
        }

        // GET: Llantas/Create
        public ActionResult Create()
        {
            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor");
            return View();
        }

        // POST: Llantas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LlantaId,NumSerie,CarroId")] Llanta llanta)
        {
            if (ModelState.IsValid)
            {
                db.Llantas.Add(llanta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", llanta.CarroId);
            return View(llanta);
        }

        // GET: Llantas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llanta llanta = db.Llantas.Find(id);
            if (llanta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", llanta.CarroId);
            return View(llanta);
        }

        // POST: Llantas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LlantaId,NumSerie,CarroId")] Llanta llanta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llanta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarroId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", llanta.CarroId);
            return View(llanta);
        }

        // GET: Llantas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llanta llanta = db.Llantas.Find(id);
            if (llanta == null)
            {
                return HttpNotFound();
            }
            return View(llanta);
        }

        // POST: Llantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Llanta llanta = db.Llantas.Find(id);
            db.Llantas.Remove(llanta);
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
