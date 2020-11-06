using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Conteudo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string Titulo { get; set; }
        [Required]
        public int ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual ICollection<Anexo> Anexos { get; set; }
    }
}