using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace _30Code.Models
{
    public class CursoVM
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Campo nome deve estar entre 3 a 100 caracteres")]
        public string Nome { get; set; }
        public string Url_imagem { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Usuario_has_curso> Usuario_Has_Cursos { get; set; }
    }
    public class AlternativaVM
    {
        public int Id { get; set; }
        public string Resposta { get; set; }
    }
    public class QuestaoVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Selecionado { get; set; }
        public List<AlternativaVM> AlternativaVMs { get; set; }
    }

    public class ModuloVM
    {
        public int Id { get; set; }
        public List<ConteudoVM> ConteudoVMs { get; set; }
    }
    public class ConteudoVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<QuestaoVM> QuestaoVMs { get; set; }
    }

    public class Aula
    {
        public CursoVM CursoVMs { get; set; }
        public List<ModuloVM> ModuloVMs { get; set; }

    }
}