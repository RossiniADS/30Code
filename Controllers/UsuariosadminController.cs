using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _30Code.Models;

namespace _30Code.Controllers
{
    public class UsuariosadminController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuariosadmin
        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Usuario pessoa = db.Usuario.Find(id);
            if (pessoa.UrlImagem != "user.png")
                Funcoes.ExcluirArquivo(Request.PhysicalApplicationPath
                + "/assets/img/Usuarios/" + pessoa.UrlImagem);
            db.Usuario.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await db.Usuario.Where(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            }

            return View(await db.Usuario.ToListAsync());
        }
        // GET: Usuariosadmin/Details/5
        public ActionResult Details(int? id)
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

        // GET: Usuariosadmin/Create
        public ActionResult Create()
        {
            return View();
        } 

        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Senha")] Usuario pessoa, HttpPostedFileBase arq)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (arq != null)
                {
                    Funcoes.CriarDiretorio("Usuarios");
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                    valor = Funcoes.UploadArquivo(arq, "Usuarios",nomearq);
                    if (valor == "sucesso")
                    {
                        pessoa.UrlImagem = nomearq;
                        db.Usuario.Add(pessoa);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                    }
                }
                else
                {
                    pessoa.UrlImagem = "user.png";
                    db.Usuario.Add(pessoa);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(pessoa);
        }

        // GET: Usuariosadmin/Edit/5
        public ActionResult Edit(int? id)
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

        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Senha,UrlImagem")] Usuario pessoa, HttpPostedFileBase arq)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (arq != null)
                {
                    Upload.CriarDiretorio();
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                    Path.GetExtension(arq.FileName);
                    valor = Upload.UploadArquivo(arq, nomearq);
                    if (valor == "sucesso")
                    {
                        if (pessoa.UrlImagem != "user.png")
                            Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" +
                            pessoa.UrlImagem);
                        pessoa.UrlImagem = nomearq;
                        db.Entry(pessoa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    Usuario pes = db.Usuario.Find(pessoa.Id);
                    pes.Nome = pessoa.Nome;
                    db.Entry(pes).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Usuariosadmin/Delete/5
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
