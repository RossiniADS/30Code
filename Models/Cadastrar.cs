using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Cadastrar
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O Campo nome deve estar entre 5 a 200 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,10})")]
        public string Senha { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }
    }
}