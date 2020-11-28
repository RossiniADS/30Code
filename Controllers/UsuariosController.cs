using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _30Code.Models;
using Rotativa;

namespace _30Code.Controllers
{
    public class UsuariosController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult SejaPremium()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create");
            }
        }


        public ActionResult MeuCertificado()
        {
            return new ViewAsPdf("PDF", db.Usuario.ToList()) { FileName = "dados.pdf" };
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var userId = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                return View(db.Usuario.Find(userId));
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                id = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                Usuario usuario = db.Usuario.Find(id);
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid)
            {
                if (db.Usuario.Where(x => x.Email == login.Cadastro.Email).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "E-mail Já utilizado!");
                    return View(login);
                }
                Usuario usu = new Usuario
                {
                    Nome = login.Cadastro.Nome,
                    Email = login.Cadastro.Email,
                    Senha = Funcoes.HashTexto(login.Cadastro.Senha, "SHA512"),
                    TiposUsuarios = Usuario.TipoUsuario.Comum,
                    UrlImagem = "user.jpg"
                };


                db.Usuario.Add(usu);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(usu.Id + "|" + usu.Nome, false);
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Usuario usuario = db.Usuario.Find(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
                EditarUsuario usu = new EditarUsuario();
                usu.Nome = usuario.Nome;
                usu.Nascimento = usuario.Nascimento;
                usu.Sexos = usuario.Sexos == Usuario.Sexo.Masculino ? EditarUsuario.Sexo.Masculino : usuario.Sexos == Usuario.Sexo.Feminino ? EditarUsuario.Sexo.Feminino : EditarUsuario.Sexo.NãoRevelar;
                usu.Celular = usuario.Celular;
                usu.Email = usuario.Email;
                usu.UrlImagem = usuario.UrlImagem;
                return View(usu);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // POST: Usuarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditarUsuario usuario, HttpPostedFileBase arq)
        {

            if (ModelState.IsValid)
            {
                var usu = db.Usuario.Find(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
                string valor = "";
                if (arq != null)
                {
                    Funcoes.CriarDiretorio("Usuarios");
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                    valor = Funcoes.UploadArquivo(arq, "Usuarios", nomearq);
                    if (valor == "sucesso")
                    {
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
                usu.Sexos = usuario.Sexos == EditarUsuario.Sexo.Masculino ? Usuario.Sexo.Masculino : usuario.Sexos == EditarUsuario.Sexo.Feminino ? Usuario.Sexo.Feminino : Usuario.Sexo.NãoRevelar;
                if (!String.IsNullOrEmpty(usuario.Senha))
                {
                    usu.Senha = Funcoes.HashTexto(usuario.Senha, "SHA512");
                }
                db.Entry(usu).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EsqueceuSenha(EsqueceuSenha esq)
        {
            if (ModelState.IsValid)
            {
                var usu = db.Usuario.Where(x => x.Email == esq.Email).ToList().FirstOrDefault();
                if (usu != null)
                {
                    usu.Hash = Funcoes.Codifica(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss.ffff"));
                    db.Entry(usu).State = EntityState.Modified;
                    db.SaveChanges();
                    string msg = "<h3>Sistema</h3>";
                    msg += "Para alterar sua senha <a href='https://localhost:44390/Usuarios/Redefinir/" + usu.Hash + "' target = '_blank' > clique aqui </ a > ";
                    Funcoes.EnviarEmail(usu.Email, "Redefinição de senha", msg);
                    TempData["MSG"] = "success|Solicitação de redefinição de senha realizada com sucesso!";
                    return RedirectToAction("Index");
                }
                TempData["MSG"] = "error|E-mail não encontrado";
                return View();
            }
            TempData["MSG"] = "warning|Preencha todos os campos";
            return View();
        }
        public ActionResult Redefinir(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var usu = db.Usuario.Where(x => x.Hash == id).ToList().FirstOrDefault();
                if (usu != null)
                {
                    try
                    {
                        DateTime dt = Convert.ToDateTime(Funcoes.Decodifica(usu.Hash));
                        if (dt > DateTime.Now)
                        {
                            RedefinirSenha red = new RedefinirSenha();
                            red.Hash = usu.Hash;
                            red.Email = usu.Email;
                            return View(red);
                        }
                        TempData["MSG"] = "warning|Esse link já expirou!";
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        TempData["MSG"] = "error|Hash inválida!";
                        return RedirectToAction("Index");
                    }
                }
                TempData["MSG"] = "error|Hash inválida!";
                return RedirectToAction("Index");
            }
            TempData["MSG"] = "error|Acesso inválido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Redefinir(RedefinirSenha red)
        {
            if (ModelState.IsValid)
            {
                var usu = db.Usuario.Where(x => x.Hash == red.Hash).ToList().FirstOrDefault();
                if (usu != null)
                {
                    usu.Hash = null;
                    usu.Senha = Funcoes.HashTexto(red.Senha, "SHA512");
                    db.Entry(usu).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["MSG"] = "success|Senha redefinida com sucesso!";
                    return RedirectToAction("Index");
                }
                TempData["MSG"] = "error|E-mail não encontrado";
                return View(red);
            }
            TempData["MSG"] = "warning|Preencha todos os campos";
            return View(red);
        }

        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Email(Mensagem msg)
        {
            if (ModelState.IsValid)
            {
                TempData["MSG"] = Funcoes.EnviarEmail(msg.Email,
                msg.Assunto, msg.CorpoMsg);
            }
            else
            {
                TempData["MSG"] = "warning|Preencha todos os campos";
            }
            return View(msg);
        }
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Create");
        }

        [Authorize]
        public ActionResult Historico()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Acesso(Login login, string ReturnUrl)
        {
            string senhacrip = Funcoes.HashTexto(login.Acesso.Senha, "SHA512");
            if (ModelState.IsValid)
            {
                Usuario usu = db.Usuario.Where(t => t.Email == login.Acesso.Email && t.Senha == senhacrip).ToList().FirstOrDefault();
                if (usu != null)
                {
                    FormsAuthentication.SetAuthCookie(usu.Id + "|" + usu.Nome, false);
                    /*
                        string permissoes = "";
                    foreach (UsuarioPerfil p in usu.UsuarioPerfil)
                    permissoes += p.Perfil.Descricao + ",";
                    permissoes = permissoes.Substring(0, permissoes.Length - 1);
                    FormsAuthenticationTicket ticket = new
                    FormsAuthenticationTicket(1, usu.Email, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, permissoes);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new
                    HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    Response.Cookies.Add(cookie);
                    */
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário/Senha inválidos");
                    return View("Create");
                }
            }
            return View(login);
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
