using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace _30Code.Models
{
    public class Cursos
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Campo nome deve estar entre 3 a 100 caracteres")]
        public string Nome { get; set; }
        public string Url_imagem { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Usuario_has_curso> Usuario_Has_Cursos { get; set; }
    }
    public class Alternativas
    {
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
    public class Questao
    {
        [Required]
        [MaxLength(80)]
        public string Titulo { get; set; }
        public int ConteudoId { get; set; }
        public virtual Conteudo Conteudo { get; set; }
        public virtual ICollection<Usuario_has_curso_has_conteudo_has_questoes> Usuario_has_curso_Has_Conteudo_Has_Questoes { get; set; }

    }
    public class Aula
    {
        public Cursos Cursos { get; set; }
        public Alternativas Alternativas { get; set; }
        public Questao Questao { get; set; }
    }
}