using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Usuario_has_curso_has_conteudo_has_questoes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Resposta { get; set; }
        [Required]
        [MaxLength(4)]
        public string Aproveitamento { get; set; }
        [Required]
        public int Usuario_has_curso_has_conteudoId { get; set; }
        public virtual Usuario_has_curso_has_conteudo Usuario_Has_Curso_Has_Conteudo { get; set; }
        public int QuestoesId { get; set; }
        public virtual Questoes Questoes { get; set; }
    }
}