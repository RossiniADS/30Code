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
    public class CursoesController : Controller
    {
        private Contexto db = new Contexto();
        public ActionResult Cursos()
        {
            return View(db.Curso.ToList());
        }

        public ActionResult Aula(int id)
        {
            Aula aula = new Aula();
            var curso = db.Curso.Find(id);

            //Conteudo cont = new Conteudo();
            //var questao = db.Questoes.Find();

            //Alternativa alter = new Alternativa();
            //var alt = db.Alternativa.Find(alter.QuestaoId);


            aula.Cursos = new Cursos();

            aula.Cursos.Nome = curso.Nome;
            aula.Cursos.Url_imagem = curso.Url_imagem;
            aula.Cursos.Modulos = curso.Modulos;
            aula.Cursos.Usuario_Has_Cursos = curso.Usuario_Has_Cursos;

            //aula.Questao = new Questao();
            //aula.Questao.Titulo = questao.Titulo;
            //aula.Questao.Conteudo = questao.Conteudo;
            //aula.Questao.ConteudoId = questao.ConteudoId;
            //aula.Questao.Usuario_has_curso_Has_Conteudo_Has_Questoes = questao.Usuario_has_curso_Has_Conteudo_Has_Questoes;

            //aula.Alternativas = new Alternativas();
            //aula.Alternativas.Resposta = alt.Resposta;
            //aula.Alternativas.Resposta2 = alt.Resposta2;
            //aula.Alternativas.Resposta3 = alt.Resposta3;
            //aula.Alternativas.Resposta4 = alt.Resposta4;
            //aula.Alternativas.Resposta5 = alt.Resposta5;
            //aula.Alternativas.AlternativaCorreta = alt.AlternativaCorreta;
            //aula.Alternativas.Questoes = alt.Questoes;
            //aula.Alternativas.QuestaoId = alt.QuestaoId;

            var usu = db.Usuario.Find(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
            if (usu == null || curso == null)
            {
                return View("Index");
            }

            var alunoCurso = db.Usuario_has_curso.FirstOrDefault(uc => uc.Curso.Id == curso.Id && uc.Usuario.Id == usu.Id);
            if (alunoCurso != null)
            {
                return View(aula);
            }
            alunoCurso = new Usuario_has_curso
            {
                UsuarioId = Convert.ToInt32(User.Identity.Name.Split('|')[0]),
                CursoId = curso.Id
            };

            db.Usuario_has_curso.Add(alunoCurso);
            db.SaveChanges();
            return View(aula);
        }
        // GET: Cursoes
        public ActionResult Index()
        {
            return View(db.Curso.ToList());
        }

        // GET: Cursoes/Details/5
        // GET: Comarcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }
        // GET: Cursoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Duracao,Url_imagem,Niveis")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Duracao,Url_imagem,Niveis")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Curso.Find(id);
            db.Curso.Remove(curso);
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
