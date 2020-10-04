using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _30Code.Models;

namespace _30Code.Controllers
{
    public class CadastrarsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cadastrars
        public ActionResult Index()
        {
            return View(db.Cadastrar.ToList());
        }

        // GET: Cadastrars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastrar cadastrar = db.Cadastrar.Find(id);
            if (cadastrar == null)
            {
                return HttpNotFound();
            }
            return View(cadastrar);
        }

        // GET: Cadastrars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastrars/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Senha,Celular")] Cadastrar cadastrar)
        {
            if (ModelState.IsValid)
            {
                db.Cadastrar.Add(cadastrar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastrar);
        }

        // GET: Cadastrars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastrar cadastrar = db.Cadastrar.Find(id);
            if (cadastrar == null)
            {
                return HttpNotFound();
            }
            return View(cadastrar);
        }

        // POST: Cadastrars/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Senha,Celular")] Cadastrar cadastrar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrar);
        }

        // GET: Cadastrars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastrar cadastrar = db.Cadastrar.Find(id);
            if (cadastrar == null)
            {
                return HttpNotFound();
            }
            return View(cadastrar);
        }

        // POST: Cadastrars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadastrar cadastrar = db.Cadastrar.Find(id);
            db.Cadastrar.Remove(cadastrar);
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
