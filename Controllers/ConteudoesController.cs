using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _30Code.Models;

namespace _30Code.Controllers
{
    public class ConteudoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Conteudoes
        public ActionResult Index()
        {
            var conteudo = db.Conteudo.Include(c => c.Modulo);
            return View(conteudo.ToList());
        }
        [HttpPost]
        public async Task<ActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Conteudo.Where(x => x.Modulo.Titulo.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Conteudo.ToListAsync());
        }
        // GET: Conteudoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteudo conteudo = db.Conteudo.Find(id);
            if (conteudo == null)
            {
                return HttpNotFound();
            }
            return View(conteudo);
        }

        // GET: Conteudoes/Create
        public ActionResult Create()
        {
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Titulo");
            return View();
        }

        // POST: Conteudoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,ModuloId")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                db.Conteudo.Add(conteudo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Titulo", conteudo.ModuloId);
            return View(conteudo);
        }

        // GET: Conteudoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteudo conteudo = db.Conteudo.Find(id);
            if (conteudo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Titulo", conteudo.ModuloId);
            return View(conteudo);
        }

        // POST: Conteudoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,ModuloId")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conteudo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Titulo", conteudo.ModuloId);
            return View(conteudo);
        }

        // GET: Conteudoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteudo conteudo = db.Conteudo.Find(id);
            if (conteudo == null)
            {
                return HttpNotFound();
            }
            return View(conteudo);
        }

        // POST: Conteudoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conteudo conteudo = db.Conteudo.Find(id);
            db.Conteudo.Remove(conteudo);
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
