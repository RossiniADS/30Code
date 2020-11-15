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
        [MaxLength(80)]
        public string Resposta { get; set; }
        [Required]
        [MaxLength(80)]
        public string Resposta2 { get; set; }
        [Required]
        [MaxLength(80)]
        public string Resposta3 { get; set; }
        [Required]
        [MaxLength(80)]
        public string Resposta4 { get; set; }
        [Required]
        [MaxLength(80)]
        public string Resposta5 { get; set; }
        [Required]
        [MaxLength(80)]
        public string AlternativaCorreta { get; set; }
        [Required]
        public int QuestaoId { get; set; }
        public virtual Questoes Questoes { get; set; }
    }
}