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
    public class VolantesController : Controller
    {
        private _2002218775DbContext db = new _2002218775DbContext();

        // GET: Volantes
        public ActionResult Index()
        {
            var volantes = db.Volantes.Include(v => v.Carro);
            return View(volantes.ToList());
        }

        // GET: Volantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // GET: Volantes/Create
        public ActionResult Create()
        {
            ViewBag.VolanteId = new SelectList(db.Carros, "CarroId", "NumSerieMotor");
            return View();
        }

        // POST: Volantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolanteId,NumSerie,CarroId")] Volante volante)
        {
            if (ModelState.IsValid)
            {
                db.Volantes.Add(volante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolanteId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", volante.VolanteId);
            return View(volante);
        }

        // GET: Volantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolanteId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", volante.VolanteId);
            return View(volante);
        }

        // POST: Volantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolanteId,NumSerie,CarroId")] Volante volante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolanteId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", volante.VolanteId);
            return View(volante);
        }

        // GET: Volantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // POST: Volantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volante volante = db.Volantes.Find(id);
            db.Volantes.Remove(volante);
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
