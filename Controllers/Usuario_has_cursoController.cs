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
    public class Usuario_has_cursoController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult MeusCursos()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var id = Convert.ToInt32(User.Identity.Name.Split('|')[0]);
                var usuCurso = db.Usuario_has_curso.Where(x => x.Usuario.Id == id).Include(u => u.Curso);
                return View(usuCurso.ToList());
            }
            else
            {
                return RedirectToAction("Create", "Usuarios");
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
