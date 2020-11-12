using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Usuario_has_curso_has_conteudo
    {
        public int Id { get; set; }
        [Required]
        public DateTime DataDeConclusao { get; set; }
        [Required]
        [MaxLength(4)]
        public string Aproveitamento { get; set; }
        [Required]
        public int Usuario_has_cursoId { get; set; }
        public virtual Usuario_has_curso Usuario_Has_Curso { get; set; }
        public int ConteudoId { get; set; }
        public virtual Conteudo Conteudo { get; set; }
        public virtual ICollection<Usuario_has_curso_has_conteudo_has_questoes> Usuario_has_curso_Has_Conteudo_Has_Questoes { get; set; }

    }
}