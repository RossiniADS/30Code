using _30Code.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _30Code.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Conteudo()
        {
            return View();
        }

        public ActionResult Curso()
        {
            return View();
        }

        public ActionResult Anexo()
        {
            return View();
        }
        // GET: Cursoes/Create
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult QuestaoAndResposta()
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

    }
}