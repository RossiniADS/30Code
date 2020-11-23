using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Campo nome deve estar entre 3 a 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 30, ErrorMessage = "O Campo nome deve estar entre 3 a 150 caracteres")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Duração")]
        public double Duracao { get; set; }
        public string Url_imagem { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Usuario_has_curso> Usuario_Has_Cursos { get; set; }
    }
}