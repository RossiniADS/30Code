﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Acesso
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,10})")]
        public string Senha { get; set; }
    }
    public class Cadastro
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O Campo nome deve estar entre 3 a 200 caracteres")]
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
        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }
    }


    public class Mensagem
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Assunto { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mensagem")]
        public string CorpoMsg { get; set; }
    }
    public class EsqueceuSenha
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
    public class RedefinirSenha
    {
        public string Email { get; set; }
        public string Hash { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter ao menos uma letra maiúscula, minúscula e um número. Deve ser no mínimo 6 caracteres")]
        public string Senha { get; set; }
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirma Senha")]
        public string ConfirmaSenha { get; set; }
    }
    public class Login
    {
        public Cadastro Cadastro { get; set; }

        public Acesso Acesso { get; set; }
    }
}