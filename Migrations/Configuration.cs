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
                    Senha = "CeCdDgvpJbV7rS0EZn7JgpqYv3UogkIhEnFBspLR/+hAkI3kSRFTjeN9Cb+/HSBuSfDjrJBbk3lLNjS1CNHSyg==",
                    Celular = "233123123",
                    UrlImagem = "gabriel.jpeg",
                    Nascimento = dt,
                    TiposUsuarios = Models.Usuario.TipoUsuario.Comum,
                    Sexos = Models.Usuario.Sexo.Masculino

                },
                new Models.Usuario
                {
                    Id = 2,
                    Nome = "Rossini Rodriguês Alves",
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
                    Nome = "Vinicius Eklund",
                    Email = "vinicius@hotmail.com",
                    Senha = "CeCdDgvpJbV7rS0EZn7JgpqYv3UogkIhEnFBspLR/+hAkI3kSRFTjeN9Cb+/HSBuSfDjrJBbk3lLNjS1CNHSyg==",
                    Celular = "8978498",
                    UrlImagem = "vinicius.png",
                    Nascimento = dt,
                    TiposUsuarios = Models.Usuario.TipoUsuario.Premiun,
                    Sexos = Models.Usuario.Sexo.Masculino
                });

            context.Curso.AddOrUpdate(
                p => p.Id,
                new Models.Curso
                {
                    Id = 1,
                    Nome = "Programação com Java",
                    Duracao = 200.00,
                    Url_imagem = "java.jpg"
                },
                new Models.Curso
                {
                    Id = 2,
                    Nome = "Programação com C##",
                    Duracao = 200.00,
                    Url_imagem = "csharp.png"
                },
                new Models.Curso
                {
                    Id = 3,
                    Nome = "Programação com C++",
                    Duracao = 200.00,
                    Url_imagem = "cpp.png"
                },
                new Models.Curso
                {
                    Id = 4,
                    Nome = "Programação com JavaScript",
                    Duracao = 200.00,
                    Url_imagem = "javascript.jpg"
                },
                new Models.Curso
                {
                    Id = 5,
                    Nome = "Kotilin",
                    Duracao = 200.00,
                    Url_imagem = "Kotilin.jpg"
                },
                new Models.Curso
                {
                    Id = 6,
                    Nome = "Banco de dados com MySql",
                    Duracao = 200.00,
                    Url_imagem = "mysql.png"
                },
                new Models.Curso
                {
                    Id = 7,
                    Nome = "NodeJs",
                    Duracao = 200.00,
                    Url_imagem = "nodejs.jpg"
                },
                new Models.Curso
                {
                    Id = 8,
                    Nome = "Banco de dados com Oracle",
                    Duracao = 200.00,
                    Url_imagem = "oracle.png"
                },
                new Models.Curso
                {
                    Id = 9,
                    Nome = "Programação com PHP",
                    Duracao = 200.00,
                    Url_imagem = "PHP.png"
                },
                new Models.Curso
                {
                    Id = 10,
                    Nome = "Programação com Python",
                    Duracao = 200.00,
                    Url_imagem = "python.png"
                },
                new Models.Curso
                {
                    Id = 11,
                    Nome = "Banco de dados com SqlServer",
                    Duracao = 200.00,
                    Url_imagem = "sql_server.png"
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
            context.Conteudo.AddOrUpdate(
                new Models.Conteudo
                {
                    Id = 1,
                    Titulo = "Variaveis",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 2,
                    Titulo = "LP",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 3,
                    Titulo = "POO",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 4,
                    Titulo = "Lambda",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 5,
                    Titulo = "Framework",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 6,
                    Titulo = "Api",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 7,
                    Titulo = "Exceções",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 8,
                    Titulo = "Interfaces",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 9,
                    Titulo = "Herança",
                    ModuloId = 3
                });
            context.Anexo.AddOrUpdate(
                new Models.Anexo
                {
                    Id = 1,
                    Titulo = "Apostila Variaveis",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 1
                },
                new Models.Anexo
                {
                    Id = 2,
                    Titulo = "Video Aula Variaveis",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 1
                },
                 new Models.Anexo
                 {
                     Id = 3,
                     Titulo = "Apostila LP",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 2
                 },
                new Models.Anexo
                {
                    Id = 4,
                    Titulo = "Video Aula LP",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 2
                },
                 new Models.Anexo
                 {
                     Id = 5,
                     Titulo = "Apostila POO",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 3
                 },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula POO",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 3
                },
                 new Models.Anexo
                 {
                     Id = 1,
                     Titulo = "Apostila Lambda",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 4
                 },
                new Models.Anexo
                {
                    Id = 2,
                    Titulo = "Video Aula Lambda",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 4
                },
                 new Models.Anexo
                 {
                     Id = 3,
                     Titulo = "Apostila Framework",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 5
                 },
                new Models.Anexo
                {
                    Id = 4,
                    Titulo = "Video Aula Framework",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 5
                },
                 new Models.Anexo
                 {
                     Id = 5,
                     Titulo = "Apostila API",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 6
                 },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula API",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 6
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Apostila Exceções",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 7
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Exceções",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 7
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Apostila Interfaces",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Interfaces",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Apostila Herança",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 9
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Video Aula Herança",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 9
                });
        }
    }
}