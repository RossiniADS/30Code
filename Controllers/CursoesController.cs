﻿using System;
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
            if (!String.IsNullOrEmpty(txtProcurar) && ModelState.IsValid)
            {
                return View(await db.Curso.Where(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Curso.ToListAsync());
        }

        [HttpPost]
        public ActionResult Resposta(ConteudoVM ConteudoVM, int id)
        {
            if (ModelState.IsValid)
            {

                int contID = 0;
                foreach (var item in ConteudoVM.QuestaoVMs)
                {
                    if (item.Selecionado == 0)
                    {
                        return RedirectToAction("Aula", "Cursoes", new { id = id });
                    }
                    contID = item.ConteudoId;
                }

                var userID = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                var usuCurso = db.Usuario_has_curso.Where(x => x.UsuarioId == userID && x.CursoId == id);

                List<Usuario_has_curso_has_conteudo_has_questoes> teste = db.Usuario_has_curso_has_conteudo_has_questoes.Where(x => x.Usuario_Has_Curso_Has_Conteudo.ConteudoId == contID && x.Usuario_Has_Curso_Has_Conteudo.Usuario_Has_Curso.UsuarioId == userID).ToList();

                if (teste.Count > 0)
                {
                    db.Usuario_has_curso_has_conteudo.Remove(teste.FirstOrDefault().Usuario_Has_Curso_Has_Conteudo);
                    foreach (var item in teste)
                    {
                        db.Usuario_has_curso_has_conteudo_has_questoes.Remove(item);
                    }
                    db.SaveChanges();
                }
                double soma = 0;
                Usuario_has_curso_has_conteudo ucc = new Usuario_has_curso_has_conteudo();
                ucc.ConteudoId = contID;
                ucc.DataDeConclusao = DateTime.Now;
                ucc.Usuario_has_cursoId = usuCurso.FirstOrDefault().Id;
                ucc.Usuario_has_curso_Has_Conteudo_Has_Questoes = new List<Usuario_has_curso_has_conteudo_has_questoes>();
                foreach (var item in ConteudoVM.QuestaoVMs)
                {
                    Usuario_has_curso_has_conteudo_has_questoes uccq = new Usuario_has_curso_has_conteudo_has_questoes();
                    uccq.AlternativaId = item.Selecionado;
                    if (db.Alternativa.Find(uccq.AlternativaId).AlternativaCorreta)
                    {
                        uccq.Aproveitamento = "100";
                        soma += 100;
                    }
                    else
                    {
                        uccq.Aproveitamento = "0";
                    }
                    uccq.QuestoesId = item.Id;
                    uccq.Resposta = item.Selecionado;
                    ucc.Usuario_has_curso_Has_Conteudo_Has_Questoes.Add(uccq);
                }
                if (soma != 0)
                {
                    ucc.Aproveitamento = (soma / ConteudoVM.QuestaoVMs.Count()).ToString();
                }
                else
                {
                    ucc.Aproveitamento = "0";
                }

                db.Usuario_has_curso_has_conteudo.Add(ucc);
                db.SaveChanges();

                return RedirectToAction("Aula", "Cursoes", new { id = id });
            }
            else
            {
                return View("Index", "Home");
            }





            //List<QuestaoVM> AlternativasCorreta = new List<QuestaoVM>();

            //foreach (QuestaoVM answser in ConteudoVM.QuestaoVMs)
            //{
            //    QuestaoVM correta = db.Questoes.Where(a => a.Id == answser.Id).Select(a => new QuestaoVM
            //    {
            //        Id = a.Id,
            //        Titulo = a.Titulo,
            //        Selecionado = a.Alternativas.Where(x => x.AlternativaCorreta == true).Select(x => x.Id).FirstOrDefault()

            //    }).FirstOrDefault();

            //    AlternativasCorreta.Add(correta);
            //}


            //var aproveitamento = 0;
            //for (int i = 0; i < AlternativasCorreta.Count(); i++)
            //{
            //    Usuario_has_curso_has_conteudo_has_questoes teste = new Usuario_has_curso_has_conteudo_has_questoes
            //    {
            //        Usuario_has_curso_has_conteudoId = 1,
            //        QuestoesId = ConteudoVM.QuestaoVMs[i].Id,
            //        AlternativaId = ConteudoVM.QuestaoVMs[i].AlternativaVMs[i].Id,
            //        Resposta = ConteudoVM.QuestaoVMs[i].Selecionado,
            //        Aproveitamento = ConteudoVM.QuestaoVMs[i].Selecionado == AlternativasCorreta[i].Selecionado ? "100" : "0",
            //    };

            //    db.Usuario_has_curso_has_conteudo_has_questoes.Add(teste);
            //}
            //aproveitamento /= 3;
            //Usuario_has_curso_has_conteudo teste2 = new Usuario_has_curso_has_conteudo
            //{
            //    Usuario_has_cursoId = 1,
            //    ConteudoId = 2,
            //    DataDeConclusao = DateTime.Now,
            //    Aproveitamento = Convert.ToString(aproveitamento)
            //};
            //db.Usuario_has_curso_has_conteudo.Add(teste2);


        }

        public ActionResult Aula(int? id)
        {
            if (User.Identity.IsAuthenticated == true && id != null)
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
                            questaoVM.ConteudoId = cont.Id;
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
                return RedirectToAction("Cadastrar", "Usuarios");
            }
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
