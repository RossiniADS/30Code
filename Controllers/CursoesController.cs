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
using X.PagedList;

namespace _30Code.Controllers
{
    public class CursoesController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Pessoas
        public async Task<ActionResult> Cursos()
        {
            return View(await db.Curso.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> Cursos(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Curso.Where(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Curso.ToListAsync());
        }
        [HttpPost]
        public ActionResult Resposta(ConteudoVM ConteudoVM)
        {
            List<QuestaoVM> AlternativasCorreta = new List<QuestaoVM>();

            foreach (QuestaoVM answser in ConteudoVM.QuestaoVMs)
            {
                QuestaoVM correta = db.Questoes.Where(a => a.Id == answser.Id).Select(a => new QuestaoVM
                {
                    Id = a.Id,
                    Titulo = a.Titulo,
                    Selecionado = a.Alternativas.Where(x => x.AlternativaCorreta == true).Select(x => x.Id).FirstOrDefault()

                }).FirstOrDefault();

                AlternativasCorreta.Add(correta);
            }

            for (int i = 0; i < AlternativasCorreta.Count(); i++)
            {
                Usuario_has_curso_has_conteudo_has_questoes teste = new Usuario_has_curso_has_conteudo_has_questoes
                {
                    Usuario_has_curso_has_conteudoId = 1,
                    QuestoesId = ConteudoVM.QuestaoVMs[i].Id,
                    AlternativaId = ConteudoVM.QuestaoVMs[i].AlternativaVMs[i].Id,
                    Resposta = ConteudoVM.QuestaoVMs[i].Selecionado,
                    Aproveitamento = ConteudoVM.QuestaoVMs[i].Selecionado == AlternativasCorreta[i].Selecionado ? "100" : "0"
                };
                db.Usuario_has_curso_has_conteudo_has_questoes.Add(teste);
            }

            db.SaveChanges();

            return View("Aula");
        }

        public ActionResult Aula(int id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Aula aula = new Aula();
                var curso = db.Curso.Find(id);

                aula.CursoVMs = new CursoVM();

                aula.CursoVMs.Nome = curso.Nome;
                aula.CursoVMs.Url_imagem = curso.Url_imagem;
                aula.CursoVMs.Modulos = curso.Modulos;
                aula.CursoVMs.Usuario_Has_Cursos = curso.Usuario_Has_Cursos;

                var usu = db.Usuario.Find(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
                if (usu == null || curso == null)
                {
                    return View("Index");
                }

                aula.ModuloVMs = new List<ModuloVM>();
                var mods = db.Modulo.Where(x => x.CursoId == curso.Id).ToList();
                foreach (var item in mods)
                {
                    ModuloVM moduloVM = new ModuloVM();
                    moduloVM.Id = item.Id;
                    moduloVM.ConteudoVMs = new List<ConteudoVM>();
                    var conteudo = db.Conteudo.Where(x => x.ModuloId == item.Id).ToList();
                    foreach (var cont in conteudo)
                    {
                        ConteudoVM conteudoVM = new ConteudoVM();
                        conteudoVM.Id = cont.Id;
                        conteudoVM.Titulo = cont.Titulo;
                        conteudoVM.QuestaoVMs = new List<QuestaoVM>();
                        var questao = db.Questoes.Where(x => x.ConteudoId == cont.Id).ToList();
                        foreach (var que in questao)
                        {
                            QuestaoVM questaoVM = new QuestaoVM();
                            questaoVM.Id = que.Id;
                            questaoVM.Titulo = que.Titulo;
                            questaoVM.AlternativaVMs = new List<AlternativaVM>();

                            var alternativas = db.Alternativa.Where(x => x.QuestoesId == que.Id).ToList();
                            foreach (var alt in alternativas)
                            {
                                AlternativaVM alternativaVM = new AlternativaVM();
                                alternativaVM.Id = alt.Id;
                                alternativaVM.Resposta = alt.Resposta;

                                questaoVM.AlternativaVMs.Add(alternativaVM);
                            }
                            conteudoVM.QuestaoVMs.Add(questaoVM);
                        }
                        moduloVM.ConteudoVMs.Add(conteudoVM);
                    }
                    aula.ModuloVMs.Add(moduloVM);
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
            else
            {
                return RedirectToAction("Create", "Usuarios");
            }
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
