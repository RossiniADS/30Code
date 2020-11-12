using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Questoes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(45)]
        public string TipoQuestao { get; set; }
        [Required]
        public int ConteudoId { get; set; }
        public virtual Conteudo Conteudo { get; set; }
        public virtual ICollection<Usuario_has_curso_has_conteudo_has_questoes> Usuario_has_curso_Has_Conteudo_Has_Questoes { get; set; }

    }
}