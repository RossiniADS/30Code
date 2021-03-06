﻿using System;
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
                return RedirectToAction("Cadastrar");
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
                return RedirectToAction("Cadastrar");
            }
        }

        // GET: Usuarios/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Usuarios/Cadastrar
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Login login)
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
                FormsAuthentication.SetAuthCookie(usu.Id + "|" + usu.Nome + "|" + usu.UrlImagem, false);
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Usuarios/EditarDados/5
        public ActionResult EditarDados()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Usuario usuario = db.Usuario.Find(Convert.ToInt32(User.Identity.Name.Split('|')[0]));
                UsuCreateEdit usu = new UsuCreateEdit();
                usu.Nome = usuario.Nome;
                usu.Nascimento = usuario.Nascimento;
                usu.Sexos = usuario.Sexos == Usuario.Sexo.Masculino ? UsuCreateEdit.Sexo.Masculino : usuario.Sexos == Usuario.Sexo.Feminino ? UsuCreateEdit.Sexo.Feminino : UsuCreateEdit.Sexo.NãoRevelar;
                usu.Celular = usuario.Celular;
                usu.Email = usuario.Email;
                usu.UrlImagem = usuario.UrlImagem;
                return View(usu);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Usuarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDados(UsuCreateEdit usuario, HttpPostedFileBase arq)
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
                        if (usu.UrlImagem != "user.jpg")
                        {
                            Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Usuarios" + "\\" + usu.UrlImagem);
                            Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath + "assets\\img\\Usuarios" + "\\mini_" + usu.UrlImagem);
                        }
                        usuario.UrlImagem = nomearq;
                        FormsAuthentication.SetAuthCookie(usu.Id + "|" + usu.Nome + "|" + usuario.UrlImagem, false);

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
                usu.Sexos = usuario.Sexos == UsuCreateEdit.Sexo.Masculino ? Usuario.Sexo.Masculino : usuario.Sexos == UsuCreateEdit.Sexo.Feminino ? Usuario.Sexo.Feminino : Usuario.Sexo.NãoRevelar;
                if (!String.IsNullOrEmpty(usuario.Senha))
                {
                    usu.Senha = Funcoes.HashTexto(usuario.Senha, "SHA512");
                }
                db.Entry(usu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditarDados");
            }
            return View(usuario);
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
            return RedirectToAction("Cadastrar");
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
                    FormsAuthentication.SetAuthCookie(usu.Id + "|" + usu.Nome + "|" + usu.UrlImagem, false);
                    string permissoes = "";
                    if (usu.TiposUsuarios.ToString() == "Admin")
                    {
                        permissoes = "Admin";
                    }
                    else if (usu.TiposUsuarios.ToString() == "Premium")
                    {
                        permissoes = "Premium";
                    }
                    else
                    {
                        permissoes = "Comum";
                    }
                    FormsAuthenticationTicket ticket = new
                    FormsAuthenticationTicket(1, usu.Id + "|" + usu.Nome + "|" + usu.UrlImagem, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, permissoes);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new
                    HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    Response.Cookies.Add(cookie);
                    if (usu.TiposUsuarios.ToString() == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário/Senha inválidos");
                    return View("Cadastrar");
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
