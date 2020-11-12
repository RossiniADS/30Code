using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Usuario_has_curso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Usuario_has_curso_has_conteudo> Usuario_Has_Curso_Has_Conteudos { get; set; }
    }
}