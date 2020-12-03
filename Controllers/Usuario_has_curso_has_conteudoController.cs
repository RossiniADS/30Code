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
    public class Usuario_has_curso_has_conteudoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuario_has_curso_has_conteudo
        public ActionResult Index()
        {
            var usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Include(u => u.Conteudo).Include(u => u.Usuario_Has_Curso);
            return View(usuario_has_curso_has_conteudo.ToList());
        }

        // GET: Usuario_has_curso_has_conteudo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Find(id);
            if (usuario_has_curso_has_conteudo == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso_has_conteudo);
        }

        // GET: Usuario_has_curso_has_conteudo/Create
        public ActionResult Create()
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");
            ViewBag.Usuario_has_cursoId = new SelectList(db.Usuario_has_curso, "Id", "Id");
            return View();
        }

        // POST: Usuario_has_curso_has_conteudo/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataDeConclusao,Aproveitamento,Usuario_has_cursoId,ConteudoId")] Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_has_curso_has_conteudo.Add(usuario_has_curso_has_conteudo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", usuario_has_curso_has_conteudo.ConteudoId);
            ViewBag.Usuario_has_cursoId = new SelectList(db.Usuario_has_curso, "Id", "Id", usuario_has_curso_has_conteudo.Usuario_has_cursoId);
            return View(usuario_has_curso_has_conteudo);
        }

        // GET: Usuario_has_curso_has_conteudo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Find(id);
            if (usuario_has_curso_has_conteudo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", usuario_has_curso_has_conteudo.ConteudoId);
            ViewBag.Usuario_has_cursoId = new SelectList(db.Usuario_has_curso, "Id", "Id", usuario_has_curso_has_conteudo.Usuario_has_cursoId);
            return View(usuario_has_curso_has_conteudo);
        }

        // POST: Usuario_has_curso_has_conteudo/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataDeConclusao,Aproveitamento,Usuario_has_cursoId,ConteudoId")] Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_has_curso_has_conteudo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", usuario_has_curso_has_conteudo.ConteudoId);
            ViewBag.Usuario_has_cursoId = new SelectList(db.Usuario_has_curso, "Id", "Id", usuario_has_curso_has_conteudo.Usuario_has_cursoId);
            return View(usuario_has_curso_has_conteudo);
        }

        // GET: Usuario_has_curso_has_conteudo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Find(id);
            if (usuario_has_curso_has_conteudo == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso_has_conteudo);
        }

        // POST: Usuario_has_curso_has_conteudo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Find(id);
            db.Usuario_has_curso_has_conteudo.Remove(usuario_has_curso_has_conteudo);
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
