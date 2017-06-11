using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2002218775_ENT;
using _2002218775_ENT.IRepositories;
using _2002218775_PER;

namespace _2002218775_MVC.Controllers
{
    public class ParabrisasController : Controller
    {
        private _2002218775DbContext db = new _2002218775DbContext();
        //private readonly IUnityOfWork _UnityOfWork;

        //public ParabrisasController(IUnityOfWork unityOfWork)
        //{
        //    _UnityOfWork = unityOfWork;
        //}

        //public ParabrisasController()
        //{

        //}
        // GET: Parabrisas
        public ActionResult Index()
        {
            var parabrisas = db.Parabrisas.Include(p => p.Carro);
            return View(parabrisas.ToList());
        }

        // GET: Parabrisas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return HttpNotFound();
            }
            return View(parabrisas);
        }

        // GET: Parabrisas/Create
        public ActionResult Create()
        {
            ViewBag.ParabrisasId = new SelectList(db.Carros, "CarroId", "NumSerieMotor");
            return View();
        }

        // POST: Parabrisas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParabrisasId,NumSerie,CarroId")] Parabrisas parabrisas)
        {
            if (ModelState.IsValid)
            {
                db.Parabrisas.Add(parabrisas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParabrisasId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", parabrisas.ParabrisasId);
            return View(parabrisas);
        }

        // GET: Parabrisas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParabrisasId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", parabrisas.ParabrisasId);
            return View(parabrisas);
        }

        // POST: Parabrisas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParabrisasId,NumSerie,CarroId")] Parabrisas parabrisas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parabrisas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParabrisasId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", parabrisas.ParabrisasId);
            return View(parabrisas);
        }

        // GET: Parabrisas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return HttpNotFound();
            }
            return View(parabrisas);
        }

        // POST: Parabrisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            db.Parabrisas.Remove(parabrisas);
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
