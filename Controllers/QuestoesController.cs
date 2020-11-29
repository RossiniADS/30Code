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
    public class QuestoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Questoes
        public ActionResult Index()
        {
            var questoes = db.Questoes.Include(q => q.Conteudo);
            return View(questoes.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Questoes.Where(x => x.Conteudo.Titulo.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Questoes.ToListAsync());
        }
        // GET: Questoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questoes questoes = db.Questoes.Find(id);
            if (questoes == null)
            {
                return HttpNotFound();
            }
            return View(questoes);
        }

        // GET: Questoes/Create
        public ActionResult Create()
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");
            return View();
        }

        // POST: Questoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,ConteudoId")] Questoes questoes)
        {
            if (ModelState.IsValid)
            {
                db.Questoes.Add(questoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", questoes.ConteudoId);
            return View(questoes);
        }

        // GET: Questoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questoes questoes = db.Questoes.Find(id);
            if (questoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", questoes.ConteudoId);
            return View(questoes);
        }

        // POST: Questoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,ConteudoId")] Questoes questoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", questoes.ConteudoId);
            return View(questoes);
        }

        // GET: Questoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questoes questoes = db.Questoes.Find(id);
            if (questoes == null)
            {
                return HttpNotFound();
            }
            return View(questoes);
        }

        // POST: Questoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questoes questoes = db.Questoes.Find(id);
            db.Questoes.Remove(questoes);
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
