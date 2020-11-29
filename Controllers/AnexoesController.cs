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
    public class AnexoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Anexoes
        public ActionResult Index()
        {
            var anexo = db.Anexo.Include(a => a.Conteudo);
            return View(anexo.ToList());
        }
        [HttpPost]
        public async Task<ActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Anexo.Where(x => x.Titulo.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Curso.ToListAsync());
        }
        // GET: Anexoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anexo anexo = db.Anexo.Find(id);
            if (anexo == null)
            {
                return HttpNotFound();
            }
            return View(anexo);
        }

        // GET: Anexoes/Create
        public ActionResult Create()
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");
            return View();
        }

        // POST: Anexoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,DataPostagem,Url,Tipos,ConteudoId")] Anexo anexo)
        {
            if (ModelState.IsValid)
            {
                db.Anexo.Add(anexo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", anexo.ConteudoId);
            return View(anexo);
        }

        // GET: Anexoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anexo anexo = db.Anexo.Find(id);
            if (anexo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", anexo.ConteudoId);
            return View(anexo);
        }

        // POST: Anexoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,DataPostagem,Url,Tipos,ConteudoId")] Anexo anexo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anexo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", anexo.ConteudoId);
            return View(anexo);
        }

        // GET: Anexoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anexo anexo = db.Anexo.Find(id);
            if (anexo == null)
            {
                return HttpNotFound();
            }
            return View(anexo);
        }

        // POST: Anexoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anexo anexo = db.Anexo.Find(id);
            db.Anexo.Remove(anexo);
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
