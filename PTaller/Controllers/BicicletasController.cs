using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conexion.Bici.Models;

namespace PTaller.Controllers
{
    public class BicicletasController : Controller
    {
        private ProyectoInacapEntities db = new ProyectoInacapEntities();

        // GET: Bicicletas
        public ActionResult Index()
        {
            return View(db.Bicicleta.ToList());
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // GET: Bicicletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBicicleta,Marca,Color,Modelo,ImagenBicicleta")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Bicicleta.Add(bicicleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBicicleta,Marca,Color,Modelo,ImagenBicicleta")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            db.Bicicleta.Remove(bicicleta);
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
