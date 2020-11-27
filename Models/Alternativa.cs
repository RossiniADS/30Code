using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Alternativa
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Resposta { get; set; }
        [Required]
        public bool AlternativaCorreta { get; set; }
        [Required]
        public int QuestoesId { get; set; }
        public virtual Questoes Questoes { get; set; }
    }
}