namespace _30Code.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_30Code.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        DateTime dt = DateTime.Parse("10/10/2010");
        protected override void Seed(_30Code.Models.Contexto context)
        {
            context.Usuario.AddOrUpdate(
                p => p.Id,
                new Models.Usuario
                {
                    Id = 1,
                    Nome = "Gabriel Oliveira",
                    Email = "gabriel@hotmail.com",
                    Senha = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                    Celular = "233123123",
                    Nascimento = dt,
                    TiposUsuarios = Models.Usuario.TipoUsuario.Comum,
                    Sexos = Models.Usuario.Sexo.Masculino

                },
                new Models.Usuario
                {
                    Id = 2,
                    Nome = "Rossini",
                    Email = "rossini_rodrigues_alves@hotmail.com",
                    Senha = "CeCdDgvpJbV7rS0EZn7JgpqYv3UogkIhEnFBspLR/+hAkI3kSRFTjeN9Cb+/HSBuSfDjrJBbk3lLNjS1CNHSyg==",
                    Celular = "35498198",
                    UrlImagem = "rossini.jpeg",
                    Nascimento = dt,
                    TiposUsuarios = Models.Usuario.TipoUsuario.Admin,
                    Sexos = Models.Usuario.Sexo.Masculino
                },
                new Models.Usuario
                {
                    Id = 3,
                    Nome = "Vinicius Santos",
                    Email = "vinicius@hotmail.com",
                    Senha = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                    Celular = "8978498",
                    Nascimento = dt,
                    TiposUsuarios = Models.Usuario.TipoUsuario.Premiun,
                    Sexos = Models.Usuario.Sexo.Masculino
                });

            context.Curso.AddOrUpdate(
                p => p.Id,
                new Models.Curso
                {
                    Id = 1,
                    Nome = "Java",
                    Duracao = 200.00,
                    Url_imagem = null
                },
                new Models.Curso
                {
                    Id = 2,
                    Nome = "C##",
                    Duracao = 200.00,
                    Url_imagem = null
                },
                new Models.Curso
                {
                    Id = 3,
                    Nome = "C++",
                    Duracao = 200.00,
                    Url_imagem = null
                },
                new Models.Curso
                {
                    Id = 4,
                    Nome = "ASP.NET",
                    Duracao = 200.00,
                    Url_imagem = null
                });
            context.Modulo.AddOrUpdate(
                new Models.Modulo
                {
                    Id = 1,
                    Titulo = "Basico",
                    CursoId = 1
                },
                new Models.Modulo
                {
                    Id = 2,
                    Titulo = "Intermediario",
                    CursoId = 1
                },
                new Models.Modulo
                {
                    Id = 3,
                    Titulo = "Avançado",
                    CursoId = 1
                },
                new Models.Modulo
                {
                    Id = 4,
                    Titulo = "Basico",
                    CursoId = 2
                },
                new Models.Modulo
                {
                    Id = 5,
                    Titulo = "Intermediario",
                    CursoId = 2
                },
                new Models.Modulo
                {
                    Id = 6,
                    Titulo = "Avançado",
                    CursoId = 2
                },
                new Models.Modulo
                {
                    Id = 7,
                    Titulo = "Basico",
                    CursoId = 3
                },
                new Models.Modulo
                {
                    Id = 8,
                    Titulo = "Intermediario",
                    CursoId = 3
                },
                new Models.Modulo
                {
                    Id = 9,
                    Titulo = "Avançado",
                    CursoId = 3
                });
            context.Tipo.AddOrUpdate(
                new Models.Tipo
                {
                    Id = 1,
                    Tipos = "Apostila"
                },
                 new Models.Tipo
                 {
                     Id = 2,
                     Tipos = "Video Aula"
                 });
            context.Conteudo.AddOrUpdate(
                new Models.Conteudo
                {
                    Id = 1,
                    Titulo = "Variaveis",
                    ModuloId = 1,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 2,
                    Titulo = "LP",
                    ModuloId = 1,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 3,
                    Titulo = "POO",
                    ModuloId = 1,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 4,
                    Titulo = "Lambda",
                    ModuloId = 2,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 5,
                    Titulo = "FrameWorkers",
                    ModuloId = 2,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 6,
                    Titulo = "Api",
                    ModuloId = 2,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 7,
                    Titulo = "Tratando Exceções",
                    ModuloId = 3,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 8,
                    Titulo = "Interfaces",
                    ModuloId = 3,
                    TipoId = 1
                },
                new Models.Conteudo
                {
                    Id = 9,
                    Titulo = "Herança",
                    ModuloId = 3,
                    TipoId = 1
                });
            context.Anexo.AddOrUpdate(
                new Models.Anexo
                {
                    Id = 1,
                    Titulo = "Apostila Variaveis",
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 1
                },
                new Models.Anexo
                {
                    Id = 2,
                    Titulo = "Video Aula Variaveis",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 1
                },
                 new Models.Anexo
                 {
                     Id = 3,
                     Titulo = "Apostila LP",
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 2
                 },
                new Models.Anexo
                {
                    Id = 4,
                    Titulo = "Video Aula LP",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 2
                },
                 new Models.Anexo
                 {
                     Id = 5,
                     Titulo = "Apostila POO",
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 3
                 },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula POO",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 3
                },
                 new Models.Anexo
                 {
                     Id = 1,
                     Titulo = "Apostila Lambda",
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 4
                 },
                new Models.Anexo
                {
                    Id = 2,
                    Titulo = "Video Aula Lambda",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 4
                },
                 new Models.Anexo
                 {
                     Id = 3,
                     Titulo = "Apostila FrameWorkers",
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 5
                 },
                new Models.Anexo
                {
                    Id = 4,
                    Titulo = "Video Aula FrameWorkers",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 5
                },
                 new Models.Anexo
                 {
                     Id = 5,
                     Titulo = "Apostila Api",
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 6
                 },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Api",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 6
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Apostila Tratando Exceções",
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 7
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Tratando Exceções",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 7
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Apostila Interfaces",
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Interfaces",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Apostila Herança",
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 9
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Herança",
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 9
                });
        }
    }
}