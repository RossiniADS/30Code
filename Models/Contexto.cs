﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base(nameOrConnectionString: "StringConexao") { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Conteudo> Conteudo { get; set; }
        public DbSet<Questoes> Questoes { get; set; }
        public DbSet<Alternativa> Alternativa { get; set; }
        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<Usuario_has_curso> Usuario_has_curso { get; set; }
        public DbSet<Usuario_has_curso_has_conteudo> Usuario_has_curso_has_conteudo { get; set; }
        public DbSet<Usuario_has_curso_has_conteudo_has_questoes> Usuario_has_curso_has_conteudo_has_questoes { get; set; }



        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }


        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
            var usu = mb.Entity<Usuario>();
            usu.ToTable("usu_usuario");
            usu.Property(x => x.Id).HasColumnName("usu_id");
            usu.Property(x => x.Nome).HasColumnName("usu_nome");
            usu.Property(x => x.Email).HasColumnName("usu_email");
            usu.Property(x => x.Senha).HasColumnName("usu_senha");
            usu.Property(x => x.Sexos).HasColumnName("usu_sexo");
            usu.Property(x => x.Nascimento).HasColumnName("usu_nascimento");
            usu.Property(x => x.UrlImagem).HasColumnName("usu_urlImagem");
            usu.Property(x => x.TiposUsuarios).HasColumnName("usu_tipoUsuario");
            usu.Property(x => x.Celular).HasColumnName("usu_celular");

            var cur = mb.Entity<Curso>();
            cur.ToTable("cur_curso");
            cur.Property(x => x.Id).HasColumnName("cur_id");
            cur.Property(x => x.Nome).HasColumnName("cur_nome");
            cur.Property(x => x.Descricao).HasColumnName("cur_descricao");
            cur.Property(x => x.Duracao).HasColumnName("cur_duracao");
            cur.Property(x => x.Url_imagem).HasColumnName("cur_url_imagem");

            var mod = mb.Entity<Modulo>();
            mod.ToTable("mod_modulo");
            mod.Property(x => x.Id).HasColumnName("mod_id");
            mod.Property(x => x.Titulo).HasColumnName("mod_titulo");
            mod.Property(x => x.CursoId).HasColumnName("cur_id");

            var cont = mb.Entity<Conteudo>();
            cont.ToTable("con_conteudo");
            cont.Property(x => x.Id).HasColumnName("con_id");
            cont.Property(x => x.Titulo).HasColumnName("con_titulo");
            cont.Property(x => x.ModuloId).HasColumnName("mod_id");

            var quest = mb.Entity<Questoes>();
            quest.ToTable("que_questoes");
            quest.Property(x => x.Id).HasColumnName("que_id");
            quest.Property(x => x.Titulo).HasColumnName("que_titulo");
            quest.Property(x => x.ConteudoId).HasColumnName("con_id");

            var alt = mb.Entity<Alternativa>();
            alt.ToTable("alt_alternativas");
            alt.Property(x => x.Id).HasColumnName("alt_id");
            alt.Property(x => x.Resposta).HasColumnName("alt_resposta");
            alt.Property(x => x.AlternativaCorreta).HasColumnName("alt_correta");
            alt.Property(x => x.QuestoesId).HasColumnName("que_id");

            var ane = mb.Entity<Anexo>();
            ane.ToTable("ane_anexos");
            ane.Property(x => x.Id).HasColumnName("ane_id");
            ane.Property(x => x.Titulo).HasColumnName("ane_titulo");
            ane.Property(x => x.Tipos).HasColumnName("ane_tipo");
            ane.Property(x => x.DataPostagem).HasColumnName("ane_dataPostagem");
            ane.Property(x => x.Url).HasColumnName("ane_url");
            ane.Property(x => x.ConteudoId).HasColumnName("con_id");

            var usuarioHasCurso = mb.Entity<Usuario_has_curso>();
            usuarioHasCurso.ToTable("usu_usuario_has_cur_curso");
            usuarioHasCurso.Property(x => x.Id).HasColumnName("id");
            usuarioHasCurso.Property(x => x.UsuarioId).HasColumnName("usu_id");
            usuarioHasCurso.Property(x => x.CursoId).HasColumnName("cur_id");

            var usuarioHasCursoHasConteudo = mb.Entity<Usuario_has_curso_has_conteudo>();
            usuarioHasCursoHasConteudo.ToTable("usuario_has_curso_has_conteudo");
            usuarioHasCursoHasConteudo.Property(x => x.Id).HasColumnName("usuario_has_curso_has_conteudo_id");
            usuarioHasCursoHasConteudo.Property(x => x.Usuario_has_cursoId).HasColumnName("usuario_has_curso_id");
            usuarioHasCursoHasConteudo.Property(x => x.ConteudoId).HasColumnName("con_id");
            usuarioHasCursoHasConteudo.Property(x => x.DataDeConclusao).HasColumnName("dataConclusao");
            usuarioHasCursoHasConteudo.Property(x => x.Aproveitamento).HasColumnName("aproveitamento");

            var usuarioHasCursoHasConteudoHasQuestoes = mb.Entity<Usuario_has_curso_has_conteudo_has_questoes>();
            usuarioHasCursoHasConteudoHasQuestoes.ToTable("usuario_has_curso_has_conteudo_has_questoes");
            usuarioHasCursoHasConteudoHasQuestoes.Property(x => x.Id).HasColumnName("id");
            usuarioHasCursoHasConteudoHasQuestoes.Property(x => x.Usuario_has_curso_has_conteudoId).HasColumnName("usuario_has_curso_has_conteudo_id");
            usuarioHasCursoHasConteudoHasQuestoes.Property(x => x.QuestoesId).HasColumnName("que_id");
            usuarioHasCursoHasConteudoHasQuestoes.Property(x => x.AlternativaId).HasColumnName("alt_id");
            usuarioHasCursoHasConteudoHasQuestoes.Property(x => x.Resposta).HasColumnName("resposta");
            usuarioHasCursoHasConteudoHasQuestoes.Property(x => x.Aproveitamento).HasColumnName("aproveitamento");
        }
    }
}