﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Anexo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string Titulo { get; set; }
        [Required]
        public DateTime DataPostagem { get; set; }
        
        [MaxLength(100)]
        [Display(Name = "Anexar arquivo")]
        public string Url { get; set; }
        [Required]
        public Tipo Tipos { get; set; }
        public enum Tipo
        {
            Apostila = 0,
            Aula = 1,
        }
        [Required]
        [Display(Name = "Conteudo")]
        public int ConteudoId { get; set; }
        public virtual Conteudo Conteudo { get; set; }
    }
}