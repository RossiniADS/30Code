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
                    Titulo = "Introdução ao curso",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 2,
                    Titulo = "Linguagem de programação",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 3,
                    Titulo = "Introdução a linguagem Java",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 4,
                    Titulo = "Variaveis",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 5,
                    Titulo = "Estrutura sequencial",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 6,
                    Titulo = "Estruturas condicionais",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 7,
                    Titulo = "Estruturas de repetição",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 8,
                    Titulo = "Outros tópicos basicos",
                    ModuloId = 1
                },
                new Models.Conteudo
                {
                    Id = 9,
                    Titulo = "Introdução a POO",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 10,
                    Titulo = "Construtores",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 11,
                    Titulo = "Sobrecarga",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 12,
                    Titulo = "encapsulamento",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 13,
                    Titulo = "Gets e Sets",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 14,
                    Titulo = "Arrays",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 15,
                    Titulo = "Listas",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 16,
                    Titulo = "Dates",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 17,
                    Titulo = "Enumeração",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 18,
                    Titulo = "Herança",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 19,
                    Titulo = "Polimorfismo",
                    ModuloId = 2
                },
                new Models.Conteudo
                {
                    Id = 20,
                    Titulo = "Tratamento de exceções",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 21,
                    Titulo = "Lendo arquivos de texto",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 22,
                    Titulo = "Interfaces",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 23,
                    Titulo = "Generics",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 24,
                    Titulo = "Set",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 25,
                    Titulo = "Map",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 26,
                    Titulo = "Expressões Lambda",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 27,
                    Titulo = "Conexão com banco de dados",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 28,
                    Titulo = "Interface grafica JavaFX",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 29,
                    Titulo = "Projeto de revisão",
                    ModuloId = 3
                },
                new Models.Conteudo
                {
                    Id = 30,
                    Titulo = "Prova final",
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
                    Id = 7,
                    Titulo = "Apostila Lambda",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 4
                },
                new Models.Anexo
                {
                    Id = 8,
                    Titulo = "Video Aula Lambda",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 4
                },
                 new Models.Anexo
                 {
                     Id = 9,
                     Titulo = "Apostila Framework",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 5
                 },
                new Models.Anexo
                {
                    Id = 10,
                    Titulo = "Video Aula Framework",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 5
                },
                 new Models.Anexo
                 {
                     Id = 11,
                     Titulo = "Apostila API",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 6
                 },
                new Models.Anexo
                {
                    Id = 12,
                    Titulo = "Video Aula API",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 6
                },
                new Models.Anexo
                {
                    Id = 13,
                    Titulo = "Apostila Exceções",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 7
                },
                new Models.Anexo
                {
                    Id = 14,
                    Titulo = "Video Aula Exceções",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 7
                },
                new Models.Anexo
                {
                    Id = 15,
                    Titulo = "Apostila Interfaces",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 16,
                    Titulo = "Video Aula Interfaces",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 17,
                    Titulo = "Apostila Herança",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 9
                },
                new Models.Anexo
                {
                    Id = 18,
                    Titulo = "Video Aula Herança",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 9
                },
                new Models.Anexo
                {
                    Id = 19,
                    Titulo = "Apostila Variaveis",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 10
                },
                new Models.Anexo
                {
                    Id = 20,
                    Titulo = "Video Aula Variaveis",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 10
                },
                 new Models.Anexo
                 {
                     Id = 21,
                     Titulo = "Apostila LP",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 11
                 },
                new Models.Anexo
                {
                    Id = 22,
                    Titulo = "Video Aula LP",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 11
                },
                 new Models.Anexo
                 {
                     Id = 23,
                     Titulo = "Apostila POO",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 12
                 },
                new Models.Anexo
                {
                    Id = 24,
                    Titulo = "Video Aula POO",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 12
                },
                 new Models.Anexo
                 {
                     Id = 25,
                     Titulo = "Apostila Lambda",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 13
                 },
                new Models.Anexo
                {
                    Id = 26,
                    Titulo = "Video Aula Lambda",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 13
                },
                 new Models.Anexo
                 {
                     Id = 27,
                     Titulo = "Apostila Framework",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 14
                 },
                new Models.Anexo
                {
                    Id = 28,
                    Titulo = "Video Aula Framework",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 14
                },
                new Models.Anexo
                {
                    Id = 29,
                    Titulo = "Apostila API",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 15
                },
                new Models.Anexo
                {
                    Id = 30,
                    Titulo = "Video Aula API",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 15
                },
                new Models.Anexo
                {
                    Id = 31,
                    Titulo = "Apostila API",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 16
                },
                new Models.Anexo
                {
                    Id = 32,
                    Titulo = "Video Aula API",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 16
                },
                new Models.Anexo
                {
                    Id = 33,
                    Titulo = "Apostila Variaveis",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 17
                },
                new Models.Anexo
                {
                    Id = 34,
                    Titulo = "Video Aula Variaveis",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 17
                },
                 new Models.Anexo
                 {
                     Id = 35,
                     Titulo = "Apostila LP",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 18
                 },
                new Models.Anexo
                {
                    Id = 36,
                    Titulo = "Video Aula LP",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 18
                },
                 new Models.Anexo
                 {
                     Id = 37,
                     Titulo = "Apostila POO",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 19
                 },
                new Models.Anexo
                {
                    Id = 38,
                    Titulo = "Video Aula POO",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 19
                },
                 new Models.Anexo
                 {
                     Id = 39,
                     Titulo = "Apostila Lambda",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 20
                 },
                new Models.Anexo
                {
                    Id = 40,
                    Titulo = "Video Aula Lambda",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 20
                },
                 new Models.Anexo
                 {
                     Id = 41,
                     Titulo = "Apostila Framework",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 21
                 },
                 new Models.Anexo
                 {
                     Id = 42,
                     Titulo = "Video Aula Framework",
                     Tipos = Models.Anexo.Tipo.Aula,
                     DataPostagem = DateTime.Now,
                     Url = "aulasvariaveis.mp4",
                     ConteudoId = 21
                 },
                 new Models.Anexo
                 {
                     Id = 43,
                     Titulo = "Apostila Framework",
                     Tipos = Models.Anexo.Tipo.Aula,
                     DataPostagem = DateTime.Now,
                     Url = "aulasvariaveis.mp4",
                     ConteudoId = 22
                 },
                 new Models.Anexo
                 {
                     Id = 44,
                     Titulo = "Video Aula Framework",
                     Tipos = Models.Anexo.Tipo.Aula,
                     DataPostagem = DateTime.Now,
                     Url = "aulasvariaveis.mp4",
                     ConteudoId = 22
                 },
                 new Models.Anexo
                 {
                     Id = 45,
                     Titulo = "Apostila API",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 23
                 },
                new Models.Anexo
                {
                    Id = 46,
                    Titulo = "Video Aula API",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 23
                },
                new Models.Anexo
                {
                    Id = 47,
                    Titulo = "Apostila Exceções",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 24
                },
                new Models.Anexo
                {
                    Id = 48,
                    Titulo = "Video Aula Exceções",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 24
                },
                new Models.Anexo
                {
                    Id = 49,
                    Titulo = "Apostila Interfaces",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 25
                },
                new Models.Anexo
                {
                    Id = 50,
                    Titulo = "Video Aula Interfaces",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 25
                },
                new Models.Anexo
                {
                    Id = 51,
                    Titulo = "Apostila Herança",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 26
                },
                new Models.Anexo
                {
                    Id = 52,
                    Titulo = "Video Aula Herança",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 26
                },
                new Models.Anexo
                {
                    Id = 53,
                    Titulo = "Apostila Variaveis",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 27
                },
                new Models.Anexo
                {
                    Id = 54,
                    Titulo = "Video Aula Variaveis",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 27
                },
                 new Models.Anexo
                 {
                     Id = 55,
                     Titulo = "Apostila LP",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 28
                 },
                new Models.Anexo
                {
                    Id = 56,
                    Titulo = "Video Aula LP",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 28
                },
                 new Models.Anexo
                 {
                     Id = 57,
                     Titulo = "Apostila POO",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 29
                 },
                new Models.Anexo
                {
                    Id = 58,
                    Titulo = "Video Aula POO",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 29
                },
                 new Models.Anexo
                 {
                     Id = 59,
                     Titulo = "Apostila Lambda",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia2.pdf",
                     ConteudoId = 30
                 },
                new Models.Anexo
                {
                    Id = 60,
                    Titulo = "Video Aula Lambda",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "aulasvariaveis.mp4",
                    ConteudoId = 30
                });
        }
    }
}