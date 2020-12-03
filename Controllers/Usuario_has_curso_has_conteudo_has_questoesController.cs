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
    public class Usuario_has_curso_has_conteudo_has_questoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuario_has_curso_has_conteudo_has_questoes
        public ActionResult Index()
        {
            var usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Include(u => u.Alternativa).Include(u => u.Questoes).Include(u => u.Usuario_Has_Curso_Has_Conteudo);
            return View(usuario_has_curso_has_conteudo_has_questoes.ToList());
        }

        // GET: Usuario_has_curso_has_conteudo_has_questoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Find(id);
            if (usuario_has_curso_has_conteudo_has_questoes == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso_has_conteudo_has_questoes);
        }

        // GET: Usuario_has_curso_has_conteudo_has_questoes/Create
        public ActionResult Create()
        {
            ViewBag.AlternativaId = new SelectList(db.Alternativa, "Id", "Resposta");
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo");
            ViewBag.Usuario_has_curso_has_conteudoId = new SelectList(db.Usuario_has_curso_has_conteudo, "Id", "Aproveitamento");
            return View();
        }

        // POST: Usuario_has_curso_has_conteudo_has_questoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Resposta,Aproveitamento,Usuario_has_curso_has_conteudoId,QuestoesId,AlternativaId")] Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_has_curso_has_conteudo_has_questoes.Add(usuario_has_curso_has_conteudo_has_questoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlternativaId = new SelectList(db.Alternativa, "Id", "Resposta", usuario_has_curso_has_conteudo_has_questoes.AlternativaId);
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo", usuario_has_curso_has_conteudo_has_questoes.QuestoesId);
            ViewBag.Usuario_has_curso_has_conteudoId = new SelectList(db.Usuario_has_curso_has_conteudo, "Id", "Aproveitamento", usuario_has_curso_has_conteudo_has_questoes.Usuario_has_curso_has_conteudoId);
            return View(usuario_has_curso_has_conteudo_has_questoes);
        }

        // GET: Usuario_has_curso_has_conteudo_has_questoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Find(id);
            if (usuario_has_curso_has_conteudo_has_questoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlternativaId = new SelectList(db.Alternativa, "Id", "Resposta", usuario_has_curso_has_conteudo_has_questoes.AlternativaId);
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo", usuario_has_curso_has_conteudo_has_questoes.QuestoesId);
            ViewBag.Usuario_has_curso_has_conteudoId = new SelectList(db.Usuario_has_curso_has_conteudo, "Id", "Aproveitamento", usuario_has_curso_has_conteudo_has_questoes.Usuario_has_curso_has_conteudoId);
            return View(usuario_has_curso_has_conteudo_has_questoes);
        }

        // POST: Usuario_has_curso_has_conteudo_has_questoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Resposta,Aproveitamento,Usuario_has_curso_has_conteudoId,QuestoesId,AlternativaId")] Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_has_curso_has_conteudo_has_questoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlternativaId = new SelectList(db.Alternativa, "Id", "Resposta", usuario_has_curso_has_conteudo_has_questoes.AlternativaId);
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo", usuario_has_curso_has_conteudo_has_questoes.QuestoesId);
            ViewBag.Usuario_has_curso_has_conteudoId = new SelectList(db.Usuario_has_curso_has_conteudo, "Id", "Aproveitamento", usuario_has_curso_has_conteudo_has_questoes.Usuario_has_curso_has_conteudoId);
            return View(usuario_has_curso_has_conteudo_has_questoes);
        }

        // GET: Usuario_has_curso_has_conteudo_has_questoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Find(id);
            if (usuario_has_curso_has_conteudo_has_questoes == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso_has_conteudo_has_questoes);
        }

        // POST: Usuario_has_curso_has_conteudo_has_questoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Find(id);
            db.Usuario_has_curso_has_conteudo_has_questoes.Remove(usuario_has_curso_has_conteudo_has_questoes);
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
