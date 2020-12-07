using _30Code.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _30Code.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private Contexto db = new Contexto();

        //----------------- Alternativas ----------------------

        // GET: Alternativas
        public ActionResult AlternativasIndex()
        {
            var alternativa = db.Alternativa.Include(a => a.Questoes);
            return View(alternativa.ToList());
        }

        // GET: Alternativas/Details/5
        public ActionResult AlternativasDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativa = db.Alternativa.Find(id);
            if (alternativa == null)
            {
                return HttpNotFound();
            }
            return View(alternativa);
        }

        // GET: Alternativas/Create
        public ActionResult AlternativasCreate()
        {
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo");
            return View();
        }

        // POST: Alternativas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlternativasCreate([Bind(Include = "Id,Resposta,AlternativaCorreta,QuestoesId")] Alternativa alternativa)
        {
            if (ModelState.IsValid)
            {
                db.Alternativa.Add(alternativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo", alternativa.QuestoesId);
            return View(alternativa);
        }

        // GET: Alternativas/Edit/5
        public ActionResult AlternativasEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativa = db.Alternativa.Find(id);
            if (alternativa == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo", alternativa.QuestoesId);
            return View(alternativa);
        }

        // POST: Alternativas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlternativasEdit([Bind(Include = "Id,Resposta,AlternativaCorreta,QuestoesId")] Alternativa alternativa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alternativa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestoesId = new SelectList(db.Questoes, "Id", "Titulo", alternativa.QuestoesId);
            return View(alternativa);
        }

        // GET: Alternativas/Delete/5
        public ActionResult AlternativasDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternativa alternativa = db.Alternativa.Find(id);
            if (alternativa == null)
            {
                return HttpNotFound();
            }
            return View(alternativa);
        }

        // POST: Alternativas/Delete/5
        [HttpPost, ActionName("AlternativasDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AlternativasDeleteConfirmed(int id)
        {
            Alternativa alternativa = db.Alternativa.Find(id);
            db.Alternativa.Remove(alternativa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //----------------- Módulos ------------------------

        // GET: Moduloes
        public ActionResult ModuloIndex()
        {
            var modulo = db.Modulo.Include(m => m.Curso);
            return View(modulo.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> ModuloIndex(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Modulo.Where(x => x.Curso.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Modulo.ToListAsync());
        }

        // GET: Moduloes/Details/5
        public ActionResult ModuloDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // GET: Moduloes/Create
        public ActionResult ModuloCreate()
        {
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome");
            return View();
        }

        // POST: Moduloes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModuloCreate([Bind(Include = "Id,Titulo,CursoId")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Modulo.Add(modulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", modulo.CursoId);
            return View(modulo);
        }

        // GET: Moduloes/Edit/5
        public ActionResult ModuloEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", modulo.CursoId);
            return View(modulo);
        }

        // POST: Moduloes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModuloEdit([Bind(Include = "Id,Titulo,CursoId")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", modulo.CursoId);
            return View(modulo);
        }

        // GET: Moduloes/Delete/5
        public ActionResult ModuloDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = db.Modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // POST: Moduloes/Delete/5
        [HttpPost, ActionName("ModuloDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ModuloDeleteConfirmed(int id)
        {
            Modulo modulo = db.Modulo.Find(id);
            db.Modulo.Remove(modulo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //--------------------- UsuHasCurso ----------------------


        public ActionResult UsuHasCurIndex()
        {
            var usuario_has_curso = db.Usuario_has_curso.Include(u => u.Curso).Include(u => u.Usuario);
            return View(usuario_has_curso.ToList());
        }

        // GET: Usuario_has_curso/Details/5
        public ActionResult UsuHasCurDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            if (usuario_has_curso == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso);
        }

        // GET: Usuario_has_curso/Create
        public ActionResult UsuHasCurCreate()
        {
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Usuario_has_curso/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuHasCurCreate([Bind(Include = "Id,UsuarioId,CursoId")] Usuario_has_curso usuario_has_curso)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_has_curso.Add(usuario_has_curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", usuario_has_curso.CursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", usuario_has_curso.UsuarioId);
            return View(usuario_has_curso);
        }

        // GET: Usuario_has_curso/Edit/5
        public ActionResult UsuHasCurEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            if (usuario_has_curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", usuario_has_curso.CursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", usuario_has_curso.UsuarioId);
            return View(usuario_has_curso);
        }

        // POST: Usuario_has_curso/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuHasCurEdit([Bind(Include = "Id,UsuarioId,CursoId")] Usuario_has_curso usuario_has_curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_has_curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", usuario_has_curso.CursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", usuario_has_curso.UsuarioId);
            return View(usuario_has_curso);
        }

        // GET: Usuario_has_curso/Delete/5
        public ActionResult UsuHasCurDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            if (usuario_has_curso == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso);
        }

        // POST: Usuario_has_curso/Delete/5
        [HttpPost, ActionName("UsuHasCurDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UsuHasCurDeleteConfirmed(int id)
        {
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            db.Usuario_has_curso.Remove(usuario_has_curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //--------------------- Cursos --------------------------

        // GET: Cursoes
        public ActionResult CursoIndex()
        {
            return View(db.Curso.ToList());
        }

        // GET: Cursoes/Details/5
        // GET: Comarcas/Details/5
        public ActionResult CursoDetails(int? id)
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
        public ActionResult CursoCreate()
        {
            return View();
        }

        // POST: Cursoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CursoCreate(Curso curso, HttpPostedFileBase arq)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (db.Curso.Where(x => x.Nome == curso.Nome).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "Nome Já utilizado!");
                    return View(curso);
                }
                else
                {
                    if (arq != null)
                    {
                        Funcoes.CriarDiretorio("Cursos");
                        string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                        valor = Funcoes.UploadArquivo(arq, "Cursos", nomearq);
                        if (valor == "sucesso")
                        {
                            curso.Url_imagem = "cur_" + nomearq;

                            db.Curso.Add(curso);
                            db.SaveChanges();
                            return RedirectToAction("CursoCreate");
                        }
                        else
                        {
                            ModelState.AddModelError("", valor);
                            return View(curso);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Carregue uma imagem");
                        return View(curso);
                    }
                }
            }
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public ActionResult CursoEdit(int? id)
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
        public ActionResult CursoEdit(Curso curso, HttpPostedFileBase arq)
        {
            string valor = "";
            var cur = db.Curso.Find(curso.Id);

            if (ModelState.IsValid)
            {
                if (db.Curso.Where(x => x.Nome == curso.Nome).ToList().Count > 1)
                {
                    ModelState.AddModelError("", "Nome Já utilizado!");
                    return View(curso);
                }
                else
                {
                    if (arq != null)
                    {
                        Funcoes.CriarDiretorio("Cursos");
                        string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                        valor = Funcoes.UploadArquivo(arq, "Cursos", nomearq);
                        if (valor == "sucesso")
                        {
                            cur.Url_imagem = "cur_" + nomearq;
                            cur.Descricao = curso.Descricao;
                            cur.Duracao = curso.Duracao;
                            cur.Nome = curso.Nome;

                            db.Entry(cur).State = EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("CursoEdit");
                        }
                        else
                        {
                            ModelState.AddModelError("", valor);
                            return View(curso);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Carregue uma imagem");
                        return View(curso);
                    }
                }
            }
            return View(curso);
        }


        // GET: Cursoes/Delete/5
        public ActionResult CursoDelete(int? id)
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
        [HttpPost, ActionName("CursoDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CursoDeleteConfirmed(int id)
        {
            Curso curso = db.Curso.Find(id);
            Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Cursos\\" + curso.Url_imagem);
            db.Curso.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //----------------- Anexos -----------------------------
        // GET: Anexoes
        public ActionResult AnexoIndex()
        {
            var anexo = db.Anexo.Include(a => a.Conteudo);
            return View(anexo.ToList());
        }
        [HttpPost]
        public async Task<ActionResult> AnexoIndex(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Anexo.Where(x => x.Titulo.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Curso.ToListAsync());
        }
        // GET: Anexoes/Details/5
        public ActionResult AnexoDetails(int? id)
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
        public ActionResult AnexoCreate()
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");
            return View();
        }

        // POST: Anexoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnexoCreate(Anexo anexo, HttpPostedFileBase arq)
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");

            string ext = Path.GetExtension(arq.FileName).ToLower();
            string valor = "";
            string pasta = "";
            if (ModelState.IsValid)
            {

                if (arq != null)
                {
                    if (anexo.Tipos.ToString() == "Aula" && ext != ".mp4")
                    {
                        ModelState.AddModelError("", "Carrega um arquivo valido do tipo aula");
                        return View(anexo);

                    }
                    else if (anexo.Tipos.ToString() == "Apostila" && ext != ".pdf")
                    {
                        ModelState.AddModelError("", "Carrega um arquivo valido do tipo apostila");
                        return View(anexo);
                    }
                    if (anexo.Tipos.ToString() == "Aula")
                    {
                        Funcoes.CriarDiretorioPDF("VideoAulas");
                        pasta = "VideoAulas";
                    }
                    else
                    {
                        Funcoes.CriarDiretorioPDF("Apostilas");
                        pasta = "Apostilas";

                    }
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);

                    valor = Funcoes.UploadArquivoPDF(arq, pasta, nomearq);

                    if (valor == "sucesso")
                    {
                        anexo.Url = nomearq;
                        anexo.DataPostagem = DateTime.Now;

                        db.Anexo.Add(anexo);
                        db.SaveChanges();
                        return RedirectToAction("AnexoCreate");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                        return View(anexo);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Carregue uma imagem");
                    return View(anexo);
                }
            }

            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", anexo.ConteudoId);
            return View(anexo);
        }

        // GET: Anexoes/Edit/5
        public ActionResult AnexoEdit(int? id)
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
        public ActionResult AnexoEdit(Anexo anexo, HttpPostedFileBase arq)
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");

            string ext = Path.GetExtension(arq.FileName).ToLower();
            string valor = "";
            string pasta = "";
            if (ModelState.IsValid)
            {
                var anexos = db.Anexo.Find(anexo.Id);

                if (arq != null)
                {
                    if (anexo.Tipos.ToString() == "Aula" && ext != ".mp4")
                    {
                        ModelState.AddModelError("", "Carrega um arquivo valido do tipo aula");
                        return View(anexo);

                    }
                    else if (anexo.Tipos.ToString() == "Apostila" && ext != ".pdf")
                    {
                        ModelState.AddModelError("", "Carrega um arquivo valido do tipo apostila");
                        return View(anexo);
                    }
                    if (anexo.Tipos.ToString() == "Aula")
                    {
                        Funcoes.CriarDiretorioPDF("VideoAulas");
                        pasta = "VideoAulas";
                    }
                    else
                    {
                        Funcoes.CriarDiretorioPDF("Apostilas");
                        pasta = "Apostilas";

                    }
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                    valor = Funcoes.UploadArquivoPDF(arq, pasta, nomearq);
                    if (valor == "sucesso")
                    {

                        string ext2 = Path.GetExtension(anexos.Url).ToLower();
                        pasta = ext2 == ".mp4" ? "VideoAulas" : "Apostilas";


                        Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\" + pasta + "\\" + anexos.Url);
                        anexos.Tipos = anexo.Tipos;
                        anexos.Titulo = anexo.Titulo;


                        anexos.Url = nomearq;
                        anexos.DataPostagem = DateTime.Now;

                        db.Entry(anexos).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("AnexoIndex");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                        return View(anexos);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Carregue uma imagem");
                    return View(anexos);
                }
            }

            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo", anexo.ConteudoId);
            return View(anexo);
        }

        // GET: Anexoes/Delete/5
        public ActionResult AnexoDelete(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnexoDelete(int id)
        {
            Anexo anexo = db.Anexo.Find(id);
            string ext2 = Path.GetExtension(anexo.Url).ToLower();
            string pasta = ext2 == ".mp4" ? "VideoAulas" : "Apostilas";

            Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\" + pasta + "\\" + anexo.Url);
            db.Anexo.Remove(anexo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //--------------------- Conteudo ------------------------

        // GET: Conteudoes
        public ActionResult ConteudoIndex()
        {
            var conteudo = db.Conteudo.Include(c => c.Modulo);
            return View(conteudo.ToList());
        }
        [HttpPost]
        public async Task<ActionResult> ConteudoIndex(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Conteudo.Where(x => x.Modulo.Titulo.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Conteudo.ToListAsync());
        }
        // GET: Conteudoes/Details/5
        public ActionResult ConteudoDetails(int? id)
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
        public ActionResult ConteudoCreate()
        {
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Titulo");
            return View();
        }

        // POST: Conteudoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConteudoCreate([Bind(Include = "Id,Titulo,ModuloId")] Conteudo conteudo)
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
        public ActionResult ConteudoEdit(int? id)
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
        public ActionResult ConteudoEdit([Bind(Include = "Id,Titulo,ModuloId")] Conteudo conteudo)
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
        public ActionResult ConteudoDelete(int? id)
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
        [HttpPost, ActionName("ConteudoDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConteudoDeleteConfirmed(int id)
        {
            Conteudo conteudo = db.Conteudo.Find(id);
            db.Conteudo.Remove(conteudo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //------------ Questoes ----------------------------

        // GET: Questoes
        public ActionResult QuestaoIndex()
        {
            var questoes = db.Questoes.Include(q => q.Conteudo);
            return View(questoes.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> QuestaoIndex(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Questoes.Where(x => x.Conteudo.Titulo.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Questoes.ToListAsync());
        }
        // GET: Questoes/Details/5
        public ActionResult QuestaoDetails(int? id)
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
        public ActionResult QuestaoCreate()
        {
            ViewBag.ConteudoId = new SelectList(db.Conteudo, "Id", "Titulo");
            return View();
        }

        // POST: Questoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuestaoCreate([Bind(Include = "Id,Titulo,ConteudoId")] Questoes questoes)
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
        public ActionResult QuestaoEdit(int? id)
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
        public ActionResult QuestaoEdit([Bind(Include = "Id,Titulo,ConteudoId")] Questoes questoes)
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
        public ActionResult QuestaoDelete(int? id)
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
        [HttpPost, ActionName("QuestaoDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult QuestaoDeleteConfirmed(int id)
        {
            Questoes questoes = db.Questoes.Find(id);
            db.Questoes.Remove(questoes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //----------------- Usuarios ------------------------

        // GET: Usuarios
        public ActionResult UsuarioIndex()
        {
            return View(db.Usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult UsuarioDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios1/Create
        public ActionResult UsuarioCreate()
        {
            return View();
        }

        // POST: Usuarios1/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioCreate(UsuCreateEdit pessoa, HttpPostedFileBase arq)
        {
            Usuario usu = new Usuario();
            string valor = "";
            if (ModelState.IsValid)
            {
                if (db.Usuario.Where(x => x.Email == pessoa.Email).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "E-mail Já utilizado!");
                    return View(pessoa);
                }
                else
                {
                    if (arq != null)
                    {
                        Funcoes.CriarDiretorio("Usuarios");
                        string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                        valor = Funcoes.UploadArquivo(arq, "Usuarios", nomearq);
                        if (valor == "sucesso")
                        {
                            usu.UrlImagem = nomearq;
                            usu.Nome = pessoa.Nome;
                            usu.Senha = Funcoes.HashTexto(pessoa.Senha, "SHA512");
                            usu.Nascimento = pessoa.Nascimento;
                            usu.Sexos = pessoa.Sexos == UsuCreateEdit.Sexo.Masculino ? Usuario.Sexo.Masculino : pessoa.Sexos == UsuCreateEdit.Sexo.Feminino ? Usuario.Sexo.Feminino : Usuario.Sexo.NãoRevelar;
                            usu.TiposUsuarios = pessoa.TiposUsuarios == UsuCreateEdit.TipoUsuario.Admin ? Usuario.TipoUsuario.Admin : pessoa.TiposUsuarios == UsuCreateEdit.TipoUsuario.Comum ? Usuario.TipoUsuario.Comum : Usuario.TipoUsuario.Premium;
                            usu.Celular = pessoa.Celular;
                            usu.Email = pessoa.Email;

                            db.Usuario.Add(usu);
                            db.SaveChanges();
                            return RedirectToAction("UsuarioCreate");
                        }
                        else
                        {
                            ModelState.AddModelError("", valor);
                            return View(pessoa);
                        }
                    }
                    else
                    {
                        usu.Nome = pessoa.Nome;
                        usu.Senha = Funcoes.HashTexto(pessoa.Senha, "SHA512");
                        usu.Nascimento = pessoa.Nascimento;
                        usu.Sexos = pessoa.Sexos == UsuCreateEdit.Sexo.Masculino ? Usuario.Sexo.Masculino : pessoa.Sexos == UsuCreateEdit.Sexo.Feminino ? Usuario.Sexo.Feminino : Usuario.Sexo.NãoRevelar;
                        usu.TiposUsuarios = pessoa.TiposUsuarios == UsuCreateEdit.TipoUsuario.Admin ? Usuario.TipoUsuario.Admin : pessoa.TiposUsuarios == UsuCreateEdit.TipoUsuario.Comum ? Usuario.TipoUsuario.Comum : Usuario.TipoUsuario.Premium;
                        usu.Celular = pessoa.Celular;
                        usu.Email = pessoa.Email;
                        usu.UrlImagem = "user.jpg";

                        db.Usuario.Add(usu);
                        db.SaveChanges();
                        return RedirectToAction("UsuarioCreate");
                    }
                }
            }
            return View(pessoa);
        }

        // GET: Usuarios/Edit/5
        public ActionResult UsuarioEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            UsuCreateEdit usu = new UsuCreateEdit();
            usu.Nome = usuario.Nome;
            usu.Nascimento = usuario.Nascimento;
            usu.TiposUsuarios = usuario.TiposUsuarios == Usuario.TipoUsuario.Admin ? UsuCreateEdit.TipoUsuario.Admin : usuario.TiposUsuarios == Usuario.TipoUsuario.Comum ? UsuCreateEdit.TipoUsuario.Comum : UsuCreateEdit.TipoUsuario.Premiun;
            usu.Sexos = usuario.Sexos == Usuario.Sexo.Masculino ? UsuCreateEdit.Sexo.Masculino : usuario.Sexos == Usuario.Sexo.Feminino ? UsuCreateEdit.Sexo.Feminino : UsuCreateEdit.Sexo.NãoRevelar;
            usu.Celular = usuario.Celular;
            usu.Email = usuario.Email;
            usu.UrlImagem = usuario.UrlImagem;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioEdit(UsuCreateEdit usuario, HttpPostedFileBase arq)
        {
            if (ModelState.IsValid)
            {
                var usu = db.Usuario.Find(usuario.Id);
                string valor = "";
                if (arq != null)
                {
                    Funcoes.CriarDiretorio("Usuarios");
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                    valor = Funcoes.UploadArquivo(arq, "Usuarios", nomearq);
                    if (valor == "sucesso")
                    {
                        if (usu.UrlImagem != "user.jpg")
                        {
                            Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Usuarios" + "\\" + usu.UrlImagem);
                            Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Usuarios" + "\\mini_" + usu.UrlImagem);
                        }
                        usuario.UrlImagem = nomearq;

                    }
                    else
                    {
                        usuario.UrlImagem = usu.UrlImagem;
                        ModelState.AddModelError("", valor);
                        return View(usuario);
                    }
                }
                else
                {
                    usuario.UrlImagem = usu.UrlImagem;
                }
                usu.Nome = usuario.Nome;
                usu.Email = usuario.Email;
                usu.UrlImagem = usuario.UrlImagem;
                usu.Celular = usuario.Celular;
                usu.Nascimento = usuario.Nascimento;
                usu.TiposUsuarios = usuario.TiposUsuarios == UsuCreateEdit.TipoUsuario.Admin ? Usuario.TipoUsuario.Admin : usuario.TiposUsuarios == UsuCreateEdit.TipoUsuario.Comum ? Usuario.TipoUsuario.Comum : Usuario.TipoUsuario.Premium;
                usu.Sexos = usuario.Sexos == UsuCreateEdit.Sexo.Masculino ? Usuario.Sexo.Masculino : usuario.Sexos == UsuCreateEdit.Sexo.Feminino ? Usuario.Sexo.Feminino : Usuario.Sexo.NãoRevelar;
                if (!String.IsNullOrEmpty(usuario.Senha))
                {
                    usu.Senha = Funcoes.HashTexto(usuario.Senha, "SHA512");
                }
                db.Entry(usu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UsuarioEdit", new { id = usuario.Id });
            }
            return View(usuario);
        }
        // GET: Usuarios/Delete/5
        public ActionResult UsuarioDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioDelete(int id)
        {
            Usuario pessoa = db.Usuario.Find(id);
            if (pessoa.UrlImagem != "user.jpg")
            {
                Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Usuarios\\" + pessoa.UrlImagem);
                Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Usuarios\\mini_" + pessoa.UrlImagem);
            }
            db.Usuario.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ----------------- UsuHasCurHasCont ------------------------ 


        // GET: Usuario_has_curso_has_conteudo
        public ActionResult UsuHasCurHasContIndex()
        {
            var usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Include(u => u.Conteudo).Include(u => u.Usuario_Has_Curso);
            return View(usuario_has_curso_has_conteudo.ToList());
        }

        // GET: Usuario_has_curso_has_conteudo/Details/5
        public ActionResult UsuHasCurHasContDetails(int? id)
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
        public ActionResult UsuHasCurHasContCreate()
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
        public ActionResult UsuHasCurHasContCreate([Bind(Include = "Id,DataDeConclusao,Aproveitamento,Usuario_has_cursoId,ConteudoId")] Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo)
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
        public ActionResult UsuHasCurHasContEdit(int? id)
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
        public ActionResult UsuHasCurHasContEdit([Bind(Include = "Id,DataDeConclusao,Aproveitamento,Usuario_has_cursoId,ConteudoId")] Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo)
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
        public ActionResult UsuHasCurHasContDelete(int? id)
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
        [HttpPost, ActionName("UsuHasCurHasContDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UsuHasCurHasContDeleteConfirmed(int id)
        {
            Usuario_has_curso_has_conteudo usuario_has_curso_has_conteudo = db.Usuario_has_curso_has_conteudo.Find(id);
            db.Usuario_has_curso_has_conteudo.Remove(usuario_has_curso_has_conteudo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // ----------------- UsuHasCurHasContHasQue ------------------------ 


        // GET: Usuario_has_curso_has_conteudo_has_questoes
        public ActionResult UsuHasCurHasContHasQueIndex()
        {
            var usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Include(u => u.Alternativa).Include(u => u.Questoes).Include(u => u.Usuario_Has_Curso_Has_Conteudo);
            return View(usuario_has_curso_has_conteudo_has_questoes.ToList());
        }

        // GET: Usuario_has_curso_has_conteudo_has_questoes/Details/5
        public ActionResult UsuHasCurHasContHasQueDetails(int? id)
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
        public ActionResult UsuHasCurHasContHasQueCreate()
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
        public ActionResult UsuHasCurHasContHasQueCreate([Bind(Include = "Id,Resposta,Aproveitamento,Usuario_has_curso_has_conteudoId,QuestoesId,AlternativaId")] Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes)
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
        public ActionResult UsuHasCurHasContHasQueEdit(int? id)
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
        public ActionResult UsuHasCurHasContHasQueEdit([Bind(Include = "Id,Resposta,Aproveitamento,Usuario_has_curso_has_conteudoId,QuestoesId,AlternativaId")] Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes)
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
        public ActionResult UsuHasCurHasContHasQueDelete(int? id)
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
        [HttpPost, ActionName("UsuHasCurHasContHasQueDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UsuHasCurHasContHasQueDeleteConfirmed(int id)
        {
            Usuario_has_curso_has_conteudo_has_questoes usuario_has_curso_has_conteudo_has_questoes = db.Usuario_has_curso_has_conteudo_has_questoes.Find(id);
            db.Usuario_has_curso_has_conteudo_has_questoes.Remove(usuario_has_curso_has_conteudo_has_questoes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //------------------ Admin -------------------- 

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Graficos()
        {
            return View();
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