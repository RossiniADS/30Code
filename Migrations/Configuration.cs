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
                    UrlImagem = "user.jpg",
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
                    UrlImagem = "user.jpg",
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
                    UrlImagem = "user.jpg",
                    Nascimento = dt,
                    TiposUsuarios = Models.Usuario.TipoUsuario.Premium,
                    Sexos = Models.Usuario.Sexo.Masculino
                });

            context.Curso.AddOrUpdate(
                p => p.Id,
                new Models.Curso
                {
                    Id = 1,
                    Nome = "Programação com Java",
                    Descricao = "Curso mais didático e completo de Java e OO. UML, JDBC, JavaFX, Spring Boot, JPA, Hibernate, MySQL, MongoDB e muito mais.",
                    Duracao = 200.00,
                    Url_imagem = "java.jpg"
                },
                new Models.Curso
                {
                    Id = 2,
                    Nome = "Programação com C#",
                    Descricao = "Curso mais didático e completo de C# UML, JDBC, JavaFX, Spring Boot, JPA, Hibernate, MySQL, MongoDB e muito mais.",
                    Duracao = 200.00,
                    Url_imagem = "csharp.png"
                },
                new Models.Curso
                {
                    Id = 3,
                    Nome = "Programação com C++",
                    Descricao = "Curso mais didático e completo de C++. UML, JDBC, JavaFX, Spring Boot, JPA, Hibernate, MySQL, MongoDB e muito mais.",
                    Duracao = 200.00,
                    Url_imagem = "cpp.png"
                },
                new Models.Curso
                {
                    Id = 4,
                    Nome = "Programação com JavaScript",
                    Descricao = "Curso mais didático e completo de JavaScript. UML, JDBC, JavaFX, Spring Boot, JPA, Hibernate, MySQL, MongoDB e muito mais.",
                    Duracao = 200.00,
                    Url_imagem = "javascript.jpg"
                },
                new Models.Curso
                {
                    Id = 5,
                    Nome = "Kotilin",
                    Descricao = "Curso mais didático e completo de Kotilin. Aprenda do Zero a Criar Apps e Jogos Android com o Kotlin para Desenvolvimento Android.",
                    Duracao = 200.00,
                    Url_imagem = "Kotilin.jpg"
                },
                new Models.Curso
                {
                    Id = 6,
                    Nome = "Banco de dados com MySql",
                    Descricao = "Curso mais didático e completo de MySql. Aprenda comandos SQL no sistema de gerenciamento de banco de dados gratuito mais popular do mercado.",
                    Duracao = 200.00,
                    Url_imagem = "mysql.png"
                },
                new Models.Curso
                {
                    Id = 7,
                    Nome = "NodeJs",
                    Descricao = "Curso mais didático e completo de NodeJs. Aprenda a criar sites e sistemas web utilizando a plataforma NodeJS e o banco de dados MongoDB.",
                    Duracao = 200.00,
                    Url_imagem = "nodejs.jpg"
                },
                new Models.Curso
                {
                    Id = 8,
                    Nome = "Banco de dados com Oracle",
                    Descricao = "Curso mais didático e completo de Oracle. Aprenda do zero SQL e PL/SQL com banco de dados Oracle e prepare-se para cerificações OCA e OCE.",
                    Duracao = 200.00,
                    Url_imagem = "oracle.png"
                },
                new Models.Curso
                {
                    Id = 9,
                    Nome = "Programação com PHP",
                    Descricao = "Curso mais didático e completo de PHP. Aprenda com especialistas a programar do básico ao avançado em um projeto completo.",
                    Duracao = 200.00,
                    Url_imagem = "PHP.png"
                },
                new Models.Curso
                {
                    Id = 10,
                    Nome = "Programação com Python",
                    Descricao = "Curso mais didático e completo de Python. Aprenda Python 3.8.5 com Expressões Lambdas, Iteradores, Geradores, Orientação a Objetos e muito mais!",
                    Duracao = 200.00,
                    Url_imagem = "python.png"
                },
                new Models.Curso
                {
                    Id = 11,
                    Nome = "Banco de dados com SQL Server",
                    Descricao = "Curso mais didático e completo de Sql Server. Aprenda do zero o ESSENCIAL para administrar e instalar Bancos de Dados SQL Server!",
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
                    Titulo = "Apostila Introdução ao curso",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia1.pdf",
                    ConteudoId = 1
                },
                new Models.Anexo
                {
                    Id = 2,
                    Titulo = "Aula Introdução ao curso",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia1.mp4",
                    ConteudoId = 1
                },
                new Models.Anexo
                {
                    Id = 3,
                    Titulo = "Apostila Linguagem de programação",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.pdf",
                    ConteudoId = 2
                },
                new Models.Anexo
                {
                    Id = 4,
                    Titulo = "Aula Linguagem de programação",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia2.mp4",
                    ConteudoId = 2
                },
                new Models.Anexo
                {
                    Id = 5,
                    Titulo = "Apostila Introdução a linguagem Java",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia3.pdf",
                    ConteudoId = 3
                },
                new Models.Anexo
                {
                    Id = 6,
                    Titulo = "Aula Introdução a linguagem Java",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia3.mp4",
                    ConteudoId = 3
                },
                new Models.Anexo
                {
                    Id = 7,
                    Titulo = "Apostila Variaveis",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia4.pdf",
                    ConteudoId = 4
                },
                new Models.Anexo
                {
                    Id = 8,
                    Titulo = "Aula Variaveis",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia4.mp4",
                    ConteudoId = 4
                },
                new Models.Anexo
                {
                    Id = 9,
                    Titulo = "Apostila Estrutura sequencial",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia5pdf",
                    ConteudoId = 5
                },
                new Models.Anexo
                {
                    Id = 10,
                    Titulo = "Aula Estrutura sequencial",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia5pdf.mp4",
                    ConteudoId = 5
                },
                new Models.Anexo
                {
                    Id = 11,
                    Titulo = "Apostila Estruturas condicionais",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia6.pdf",
                    ConteudoId = 6
                },
                new Models.Anexo
                {
                    Id = 12,
                    Titulo = "Aula Estruturas condicionais",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia6.mp4",
                    ConteudoId = 6
                },
                 new Models.Anexo
                 {
                     Id = 13,
                     Titulo = "Apostila Estruturas de repetição",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia7.pdf",
                     ConteudoId = 7
                 },
                new Models.Anexo
                {
                    Id = 14,
                    Titulo = "Aula Estruturas de repetição",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia7.mp4",
                    ConteudoId = 7
                },
                 new Models.Anexo
                 {
                     Id = 15,
                     Titulo = "Apostila Outros tópicos basicos",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia8.pdf",
                     ConteudoId = 8
                 },
                new Models.Anexo
                {
                    Id = 16,
                    Titulo = "Aula Outros tópicos basicos",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia8.mp4",
                    ConteudoId = 8
                },
                new Models.Anexo
                {
                    Id = 17,
                    Titulo = "Apostila Introdução a POO",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia9.pdf",
                    ConteudoId = 9
                },
                new Models.Anexo
                {
                    Id = 18,
                    Titulo = "Aula Introdução a POO",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia9.mp4",
                    ConteudoId = 9
                },
                new Models.Anexo
                {
                    Id = 19,
                    Titulo = "Apostila Construtores",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia10.pdf",
                    ConteudoId = 10
                },
                new Models.Anexo
                {
                    Id = 20,
                    Titulo = "Aula Construtores",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia10.mp4",
                    ConteudoId = 10
                },
                new Models.Anexo
                {
                    Id = 21,
                    Titulo = "Apostila Sobrecarga",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia11.pdf",
                    ConteudoId = 11
                },
                new Models.Anexo
                {
                    Id = 22,
                    Titulo = "Aula Sobrecarga",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia11.mp4",
                    ConteudoId = 11
                },
                new Models.Anexo
                {
                    Id = 23,
                    Titulo = "Apostila encapsulamento",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia12.pdf",
                    ConteudoId = 12
                },
                new Models.Anexo
                {
                    Id = 24,
                    Titulo = "Aula encapsulamento",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia12.mp4",
                    ConteudoId = 12
                },
                 new Models.Anexo
                 {
                     Id = 25,
                     Titulo = "Apostila Gets e Sets",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia13.pdf",
                     ConteudoId = 13
                 },
                new Models.Anexo
                {
                    Id = 26,
                    Titulo = "Aula Gets e Sets",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia13.mp4",
                    ConteudoId = 13
                },
                 new Models.Anexo
                 {
                     Id = 27,
                     Titulo = "Apostila Arrays",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia14.pdf",
                     ConteudoId = 14
                 },
                new Models.Anexo
                {
                    Id = 28,
                    Titulo = "Aula Arrays",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia14.mp4",
                    ConteudoId = 14
                },
                 new Models.Anexo
                 {
                     Id = 29,
                     Titulo = "Apostila Listas",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia15.pdf",
                     ConteudoId = 15
                 },
                new Models.Anexo
                {
                    Id = 30,
                    Titulo = "Aula Listas",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia15.mp4",
                    ConteudoId = 15
                },
                 new Models.Anexo
                 {
                     Id = 31,
                     Titulo = "Apostila Dates",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia16.pdf",
                     ConteudoId = 16
                 },
                new Models.Anexo
                {
                    Id = 32,
                    Titulo = "Aula Dates",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia16.mp4",
                    ConteudoId = 16
                },
                new Models.Anexo
                {
                    Id = 33,
                    Titulo = "Apostila Enumeração",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia17.pdf",
                    ConteudoId = 17
                },
                new Models.Anexo
                {
                    Id = 34,
                    Titulo = "Aula Enumeração",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia17.mp4",
                    ConteudoId = 17
                },
                new Models.Anexo
                {
                    Id = 35,
                    Titulo = "Apostila Herança",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia18.pdf",
                    ConteudoId = 18
                },
                new Models.Anexo
                {
                    Id = 36,
                    Titulo = "Aula Herança",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia18.mp4",
                    ConteudoId = 18
                },
                new Models.Anexo
                {
                    Id = 37,
                    Titulo = "Apostila Polimorfismo",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia19.pdf",
                    ConteudoId = 19
                },
                new Models.Anexo
                {
                    Id = 38,
                    Titulo = "Aula Polimorfismo",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia19.mp4",
                    ConteudoId = 19
                },
                 new Models.Anexo
                 {
                     Id = 39,
                     Titulo = "Apostila Tratamento de exceções",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia20.pdf",
                     ConteudoId = 20
                 },
                new Models.Anexo
                {
                    Id = 40,
                    Titulo = "Aula Tratamento de exceções",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia20.mp4",
                    ConteudoId = 20
                },
                 new Models.Anexo
                 {
                     Id = 41,
                     Titulo = "Apostila Lendo arquivos de texto",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia21.pdf",
                     ConteudoId = 21
                 },
                new Models.Anexo
                {
                    Id = 42,
                    Titulo = "Aula Lendo arquivos de texto",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia21.mp4",
                    ConteudoId = 21
                },
                 new Models.Anexo
                 {
                     Id = 43,
                     Titulo = "Apostila Interfaces",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia22.pdf",
                     ConteudoId = 22
                 },
                new Models.Anexo
                {
                    Id = 44,
                    Titulo = "Aula Interfaces",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia22.mp4",
                    ConteudoId = 22
                },
                 new Models.Anexo
                 {
                     Id = 45,
                     Titulo = "Apostila Generics",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia23.pdf",
                     ConteudoId = 23
                 },
                 new Models.Anexo
                 {
                     Id = 46,
                     Titulo = "Aula Generics",
                     Tipos = Models.Anexo.Tipo.Aula,
                     DataPostagem = DateTime.Now,
                     Url = "Dia23.mp4",
                     ConteudoId = 23
                 },
                 new Models.Anexo
                 {
                     Id = 47,
                     Titulo = "Apostila Set",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia24.pdf",
                     ConteudoId = 24
                 },
                 new Models.Anexo
                 {
                     Id = 48,
                     Titulo = "Aula Set",
                     Tipos = Models.Anexo.Tipo.Aula,
                     DataPostagem = DateTime.Now,
                     Url = "Dia24.mp4",
                     ConteudoId = 24
                 },
                 new Models.Anexo
                 {
                     Id = 49,
                     Titulo = "Apostila Map",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia25.pdf",
                     ConteudoId = 25
                 },
                new Models.Anexo
                {
                    Id = 50,
                    Titulo = "Aula Map",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia25.mp4",
                    ConteudoId = 25
                },
                new Models.Anexo
                {
                    Id = 51,
                    Titulo = "Apostila Expressões Lambda",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia26.pdf",
                    ConteudoId = 26
                },
                new Models.Anexo
                {
                    Id = 52,
                    Titulo = "Aula Expressões Lambda",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia26.mp4",
                    ConteudoId = 26
                },
                new Models.Anexo
                {
                    Id = 53,
                    Titulo = "Apostila Conexão com banco de dados",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia27.pdf",
                    ConteudoId = 27
                },
                new Models.Anexo
                {
                    Id = 54,
                    Titulo = "Aula Conexão com banco de dados",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia27.mp4",
                    ConteudoId = 27
                },
                new Models.Anexo
                {
                    Id = 55,
                    Titulo = "Apostila Interface grafica JavaFX",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia28.pdf",
                    ConteudoId = 28
                },
                new Models.Anexo
                {
                    Id = 56,
                    Titulo = "Aula Interface grafica JavaFX",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia28.mp4",
                    ConteudoId = 28
                },
                new Models.Anexo
                {
                    Id = 57,
                    Titulo = "Apostila Projeto de revisão",
                    Tipos = Models.Anexo.Tipo.Apostila,
                    DataPostagem = DateTime.Now,
                    Url = "Dia29.pdf",
                    ConteudoId = 29
                },
                new Models.Anexo
                {
                    Id = 58,
                    Titulo = "Aula Projeto de revisão",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia29.mp4",
                    ConteudoId = 29
                },
                 new Models.Anexo
                 {
                     Id = 59,
                     Titulo = "Apostila Prova final",
                     Tipos = Models.Anexo.Tipo.Apostila,
                     DataPostagem = DateTime.Now,
                     Url = "Dia30.pdf",
                     ConteudoId = 30
                 },
                new Models.Anexo
                {
                    Id = 60,
                    Titulo = "Aula Prova final",
                    Tipos = Models.Anexo.Tipo.Aula,
                    DataPostagem = DateTime.Now,
                    Url = "Dia30.mp4",
                    ConteudoId = 30
                });
            context.Usuario_has_curso.AddOrUpdate(
                new Models.Usuario_has_curso
                {
                    Id = 1,
                    UsuarioId = 2,
                    CursoId = 1,
                },
                 new Models.Usuario_has_curso
                 {
                     Id = 2,
                     UsuarioId = 1,
                     CursoId = 1,
                 });
            context.Usuario_has_curso_has_conteudo.AddOrUpdate(
                new Models.Usuario_has_curso_has_conteudo
                {
                    Id = 1,
                    Usuario_has_cursoId = 1,
                    ConteudoId = 1,
                    DataDeConclusao = DateTime.Now,
                    Aproveitamento = "90"
                },
                new Models.Usuario_has_curso_has_conteudo
                {
                    Id = 2,
                    Usuario_has_cursoId = 2,
                    ConteudoId = 1,
                    DataDeConclusao = DateTime.Now,
                    Aproveitamento = "90"
                },
                new Models.Usuario_has_curso_has_conteudo
                {
                    Id = 3,
                    Usuario_has_cursoId = 2,
                    ConteudoId = 2,
                    DataDeConclusao = DateTime.Now,
                    Aproveitamento = "90"
                });
            context.Questoes.AddOrUpdate(
                new Models.Questoes
                {
                    Id = 1,
                    Titulo = "Qual a melhor linguagem?",
                    ConteudoId = 1
                },
                new Models.Questoes
                {
                    Id = 2,
                    Titulo = "Qual a linguagem da moda?",
                    ConteudoId = 1
                },
                new Models.Questoes
                {
                    Id = 3,
                    Titulo = "Qual a melhor profissão?",
                    ConteudoId = 1
                },
                 new Models.Questoes
                 {
                     Id = 4,
                     Titulo = "Não é uma funcionalidade de IDE:",
                     ConteudoId = 2
                 },
                new Models.Questoes
                {
                    Id = 5,
                    Titulo = "Não é uma vantagem da abordagem hibrida:",
                    ConteudoId = 2
                },
                new Models.Questoes
                {
                    Id = 6,
                    Titulo = "A maneira correta de se escrever um codigo é seguindo por:",
                    ConteudoId = 2
                },
                new Models.Questoes
                {
                    Id = 7,
                    Titulo = "Qual a diferença entre JRE e JDK aparece incorreta?",
                    ConteudoId = 3
                },
                new Models.Questoes
                {
                    Id = 8,
                    Titulo = "Quais são os componentes da JDK?",
                    ConteudoId = 3
                },
                new Models.Questoes
                {
                    Id = 9,
                    Titulo = "O método main sera reconhecido pelo jvm se ele possuir:",
                    ConteudoId = 3
                },
                 new Models.Questoes
                 {
                     Id = 10,
                     Titulo = "Qual desses é a maneira incorreta de se nomear uma variável?",
                     ConteudoId = 4
                 },
                new Models.Questoes
                {
                    Id = 11,
                    Titulo = "Uma variável é:",
                    ConteudoId = 4
                },
                new Models.Questoes
                {
                    Id = 12,
                    Titulo = "assinale a incorreta:",
                    ConteudoId = 4
                },
                new Models.Questoes
                {
                    Id = 13,
                    Titulo = "A maneira correta de se escrever um codigo sequencial é seguindo por:",
                    ConteudoId = 5
                },
                new Models.Questoes
                {
                    Id = 14,
                    Titulo = "É corretor afirmar de uma estrutura sequencial:",
                    ConteudoId = 5
                },
                new Models.Questoes
                {
                    Id = 15,
                    Titulo = "Para o seu correto funcionamento, os algoritmos devem ser implementados como um conjunto de métodos e mensagens.",
                    ConteudoId = 5
                },
                 new Models.Questoes
                 {
                     Id = 16,
                     Titulo = "é corretor afirmar que:",
                     ConteudoId = 6
                 },
                new Models.Questoes
                {
                    Id = 17,
                    Titulo = "É importante ressaltar:",
                    ConteudoId = 6
                },
                new Models.Questoes
                {
                    Id = 18,
                    Titulo = "Nas estruturas de controle, tais como as estruturas de seleção simples, compostas ou encadeadas, é necessário verificar as condições para a realização de uma instrução ou sequência de instruções.",
                    ConteudoId = 6
                },
                new Models.Questoes
                {
                    Id = 19,
                    Titulo = "É corretor afirmar sobre os laços while:",
                    ConteudoId = 7
                },
                new Models.Questoes
                {
                    Id = 20,
                    Titulo = "O laço mais utilizado para contagem é:",
                    ConteudoId = 7
                },
                new Models.Questoes
                {
                    Id = 21,
                    Titulo = "complete corretamente: For(............... ; ...............; ..............){}",
                    ConteudoId = 7
                },
                 new Models.Questoes
                 {
                     Id = 22,
                     Titulo = "sobre os Operadores bitwise &, | e ^ são respectivamente;",
                     ConteudoId = 8
                 },
                new Models.Questoes
                {
                    Id = 23,
                    Titulo = "dado a operação de split responda corretamente:",
                    ConteudoId = 8
                },
                new Models.Questoes
                {
                    Id = 24,
                    Titulo = "Nas funções matemáticas em Java para se obter a porcentagem de um número devemos fazer a seguinte:",
                    ConteudoId = 8
                },
                new Models.Questoes
                {
                    Id = 25,
                    Titulo = "O que é um Objeto?",
                    ConteudoId = 9
                },
                new Models.Questoes
                {
                    Id = 26,
                    Titulo = "O que é uma classe?",
                    ConteudoId = 9
                },
                new Models.Questoes
                {
                    Id = 27,
                    Titulo = "O que é um método?",
                    ConteudoId = 9
                },
                 new Models.Questoes
                 {
                     Id = 28,
                     Titulo = "Dado as características do construtor afirme o correto:",
                     ConteudoId = 10
                 },
                new Models.Questoes
                {
                    Id = 29,
                    Titulo = "Como ocorre uma chamada de um construtor pai?",
                    ConteudoId = 10
                },
                new Models.Questoes
                {
                    Id = 30,
                    Titulo = "Sobre associações obrigatórias:",
                    ConteudoId = 10
                },
                new Models.Questoes
                {
                    Id = 31,
                    Titulo = "Assine o incorreto sobre sobrecarga:",
                    ConteudoId = 11
                },
                new Models.Questoes
                {
                    Id = 32,
                    Titulo = "assine o correto sobre sobrecarga:",
                    ConteudoId = 11
                },
                new Models.Questoes
                {
                    Id = 33,
                    Titulo = "O que é sobrecarga?",
                    ConteudoId = 11
                },
                 new Models.Questoes
                 {
                     Id = 34,
                     Titulo = "Sobre encapsulamento é incorreto dizer que:",
                     ConteudoId = 12
                 },
                new Models.Questoes
                {
                    Id = 35,
                    Titulo = "Os modificadores de acesso são:",
                    ConteudoId = 12
                },
                new Models.Questoes
                {
                    Id = 36,
                    Titulo = "A regra geral para o uso do encapsulamento diz que:",
                    ConteudoId = 12
                },
                new Models.Questoes
                {
                    Id = 37,
                    Titulo = "Para criar métodos GET e SET:",
                    ConteudoId = 13
                },
                new Models.Questoes
                {
                    Id = 38,
                    Titulo = "Como usar os métodos Get e SET?",
                    ConteudoId = 13
                },
                new Models.Questoes
                {
                    Id = 39,
                    Titulo = "Uso errado do get-set pode ser:",
                    ConteudoId = 13
                },
                 new Models.Questoes
                 {
                     Id = 40,
                     Titulo = "Os erros de NullPointerException vão acontecer se você:",
                     ConteudoId = 14
                 },
                new Models.Questoes
                {
                    Id = 41,
                    Titulo = "Sobre arrays quando iniciados sendo double, float, long e boolean; devem inicialmente ser mostrados respectivamente como",
                    ConteudoId = 14
                },
                new Models.Questoes
                {
                    Id = 42,
                    Titulo = "Sobre a declaração de Array:",
                    ConteudoId = 14
                },
                new Models.Questoes
                {
                    Id = 43,
                    Titulo = "Lista é uma estrutura de dados:",
                    ConteudoId = 15
                },
                new Models.Questoes
                {
                    Id = 44,
                    Titulo = "assine a vantagem incorreta de se usar listas:",
                    ConteudoId = 15
                },
                new Models.Questoes
                {
                    Id = 45,
                    Titulo = "As principais subclasses de uma lista podem ser:",
                    ConteudoId = 15
                },
                 new Models.Questoes
                 {
                     Id = 46,
                     Titulo = "Como instancia um Calendar no Java:",
                     ConteudoId = 16
                 },
                new Models.Questoes
                {
                    Id = 47,
                    Titulo = "Porque não precisa usar o new(instanciar) o Calendar;",
                    ConteudoId = 16
                },
                new Models.Questoes
                {
                    Id = 48,
                    Titulo = "Coloque marque a alternativa correta de acordo com as alternativas:",
                    ConteudoId = 16
                },
                new Models.Questoes
                {
                    Id = 49,
                    Titulo = "Eu Gabriel criei um enumerador chamado “MinhaClasse”Como que declara um Enumerador:",
                    ConteudoId = 17
                },
                new Models.Questoes
                {
                    Id = 50,
                    Titulo = "Quais são as regras e as boas práticas para criar as variáveis dentro de um enumerador",
                    ConteudoId = 17
                },
                new Models.Questoes
                {
                    Id = 51,
                    Titulo = "O que é enum em Java:",
                    ConteudoId = 17
                },
                 new Models.Questoes
                 {
                     Id = 52,
                     Titulo = "A herança  um princípio de orientação a objetos que permite que classes compartilhem atributos e métodos  é utilizada para reaproveitar código ou comportamento generalizado ou especializar operações ou atributos.",
                     ConteudoId = 18
                 },
                new Models.Questoes
                {
                    Id = 53,
                    Titulo = "Quais afirmações são verdadeiras? (Escolha todas as opções aplicáveis.)",
                    ConteudoId = 18
                },
                new Models.Questoes
                {
                    Id = 54,
                    Titulo = "Pessoa - nome: string - idade: int - sexo: char - endereço: varchar Tendo como referência as informações precedentes, julgue o item a seguir, com base na orientação a objetos. sexo é uma herança de outra classe.",
                    ConteudoId = 18
                });
            //new Models.Questoes
            //{
            //    Id = 55,
            //    Titulo = "O que é polimorfismo?",
            //    ConteudoId = 19
            //},
            //new Models.Questoes
            //{
            //    Id = 56,
            //    Titulo = "",
            //    ConteudoId = 19
            //},
            //new Models.Questoes
            //{
            //    Id = 57,
            //    Titulo = "",
            //    ConteudoId = 19
            //},
            // new Models.Questoes
            // {
            //     Id = 58,
            //     Titulo = "",
            //     ConteudoId = 20
            // },
            //new Models.Questoes
            //{
            //    Id = 59,
            //    Titulo = "",
            //    ConteudoId = 20
            //},
            //new Models.Questoes
            //{
            //    Id = 60,
            //    Titulo = "",
            //    ConteudoId = 20
            //},
            //new Models.Questoes
            //{
            //    Id = 61,
            //    Titulo = "",
            //    ConteudoId = 21
            //},
            //new Models.Questoes
            //{
            //    Id = 62,
            //    Titulo = "",
            //    ConteudoId = 21
            //},
            //new Models.Questoes
            //{
            //    Id = 63,
            //    Titulo = "",
            //    ConteudoId = 21
            //},
            // new Models.Questoes
            // {
            //     Id = 64,
            //     Titulo = "",
            //     ConteudoId = 22
            // },
            //new Models.Questoes
            //{
            //    Id = 65,
            //    Titulo = "",
            //    ConteudoId = 22
            //},
            //new Models.Questoes
            //{
            //    Id = 66,
            //    Titulo = "",
            //    ConteudoId = 22
            //},
            //new Models.Questoes
            //{
            //    Id = 67,
            //    Titulo = "",
            //    ConteudoId = 23
            //},
            //new Models.Questoes
            //{
            //    Id = 68,
            //    Titulo = "",
            //    ConteudoId = 23
            //},
            //new Models.Questoes
            //{
            //    Id = 69,
            //    Titulo = "",
            //    ConteudoId = 23
            //},
            // new Models.Questoes
            // {
            //     Id = 70,
            //     Titulo = "",
            //     ConteudoId = 24
            // },
            //new Models.Questoes
            //{
            //    Id = 71,
            //    Titulo = "",
            //    ConteudoId = 24
            //},
            //new Models.Questoes
            //{
            //    Id = 72,
            //    Titulo = "",
            //    ConteudoId = 24
            //},
            //new Models.Questoes
            //{
            //    Id = 73,
            //    Titulo = "",
            //    ConteudoId = 25
            //},
            //new Models.Questoes
            //{
            //    Id = 74,
            //    Titulo = "",
            //    ConteudoId = 25
            //},
            //new Models.Questoes
            //{
            //    Id = 75,
            //    Titulo = "",
            //    ConteudoId = 25
            //},
            //new Models.Questoes
            //{
            //    Id = 76,
            //    Titulo = "",
            //    ConteudoId = 26
            //},
            //new Models.Questoes
            //{
            //    Id = 77,
            //    Titulo = "",
            //    ConteudoId = 26
            //},
            //new Models.Questoes
            //{
            //    Id = 78,
            //    Titulo = "",
            //    ConteudoId = 26
            //},
            //new Models.Questoes
            //{
            //    Id = 79,
            //    Titulo = "",
            //    ConteudoId = 27
            //},
            //new Models.Questoes
            //{
            //    Id = 80,
            //    Titulo = "",
            //    ConteudoId = 27
            //},
            //new Models.Questoes
            //{
            //    Id = 81,
            //    Titulo = "",
            //    ConteudoId = 27
            //},
            //new Models.Questoes
            //{
            //    Id = 82,
            //    Titulo = "",
            //    ConteudoId = 28
            //},
            //new Models.Questoes
            //{
            //    Id = 83,
            //    Titulo = "",
            //    ConteudoId = 28
            //},
            // new Models.Questoes
            // {
            //     Id = 84,
            //     Titulo = "",
            //     ConteudoId = 28
            // },
            //new Models.Questoes
            //{
            //    Id = 85,
            //    Titulo = "",
            //    ConteudoId = 29
            //},
            //new Models.Questoes
            //{
            //    Id = 86,
            //    Titulo = "",
            //    ConteudoId = 29
            //},
            //new Models.Questoes
            //{
            //    Id = 87,
            //    Titulo = "",
            //    ConteudoId = 29
            //});
            context.Alternativa.AddOrUpdate(
                new Models.Alternativa
                {
                    Id = 1,
                    Resposta = "Java",
                    AlternativaCorreta = true,
                    QuestoesId = 1
                },
                new Models.Alternativa
                {
                    Id = 2,
                    Resposta = "C#",
                    AlternativaCorreta = false,
                    QuestoesId = 1
                },
                new Models.Alternativa
                {
                    Id = 3,
                    Resposta = "Programador",
                    AlternativaCorreta = false,
                    QuestoesId = 1
                },

                new Models.Alternativa
                {
                    Id = 4,
                    Resposta = "Java",
                    AlternativaCorreta = false,
                    QuestoesId = 2
                },
                new Models.Alternativa
                {
                    Id = 5,
                    Resposta = "Python",
                    AlternativaCorreta = true,
                    QuestoesId = 2
                },
                new Models.Alternativa
                {
                    Id = 6,
                    Resposta = "Programador",
                    AlternativaCorreta = false,
                    QuestoesId = 2
                },

                new Models.Alternativa
                {
                    Id = 7,
                    Resposta = "Java",
                    AlternativaCorreta = false,
                    QuestoesId = 3
                },
                new Models.Alternativa
                {
                    Id = 8,
                    Resposta = "ASP",
                    AlternativaCorreta = false,
                    QuestoesId = 3
                },
                new Models.Alternativa
                {
                    Id = 9,
                    Resposta = "Programador",
                    AlternativaCorreta = true,
                    QuestoesId = 3
                },

                new Models.Alternativa
                {
                    Id = 10,
                    Resposta = "autocorreção de bugs",
                    AlternativaCorreta = true,
                    QuestoesId = 4
                },
                new Models.Alternativa
                {
                    Id = 11,
                    Resposta = "sugestão de modelos",
                    AlternativaCorreta = false,
                    QuestoesId = 4
                },
                new Models.Alternativa
                {
                    Id = 12,
                    Resposta = "depuração de testes",
                    AlternativaCorreta = false,
                    QuestoesId = 4
                },

                new Models.Alternativa
                {
                    Id = 13,
                    Resposta = "Velocidade do programa",
                    AlternativaCorreta = false,
                    QuestoesId = 5
                },
                new Models.Alternativa
                {
                    Id = 14,
                    Resposta = "Expressividade da linguagem",
                    AlternativaCorreta = false,
                    QuestoesId = 5
                },
                new Models.Alternativa
                {
                    Id = 15,
                    Resposta = "Automação na interpretação de códigos",
                    AlternativaCorreta = true,
                    QuestoesId = 5
                },

                new Models.Alternativa
                {
                    Id = 16,
                    Resposta = "início – entrada - resultados - processamento - fim",
                    AlternativaCorreta = false,
                    QuestoesId = 6
                },
                new Models.Alternativa
                {
                    Id = 17,
                    Resposta = "início - variáveis – processamento – informações - fim",
                    AlternativaCorreta = false,
                    QuestoesId = 6
                },
                new Models.Alternativa
                {
                    Id = 18,
                    Resposta = "início – entrada – processamento – saida - fim",
                    AlternativaCorreta = true,
                    QuestoesId = 6
                },

                new Models.Alternativa
                {
                    Id = 19,
                    Resposta = "O JRE contém tudo aquilo que um usuário comum precisa para executar uma aplicação Java.",
                    AlternativaCorreta = false,
                    QuestoesId = 7
                },
                new Models.Alternativa
                {
                    Id = 20,
                    Resposta = "O JDK é composto pelo JRE e um conjunto de ferramentas úteis ao desenvolvedor Java.",
                    AlternativaCorreta = false,
                    QuestoesId = 7
                },
                new Models.Alternativa
                {
                    Id = 21,
                    Resposta = "O JDK é uma máquina imaginária que emula uma aplicação em uma máquina real.",
                    AlternativaCorreta = true,
                    QuestoesId = 7
                },

                new Models.Alternativa
                {
                    Id = 22,
                    Resposta = "Javac, javaw, jit",
                    AlternativaCorreta = false,
                    QuestoesId = 8
                },
                new Models.Alternativa
                {
                    Id = 23,
                    Resposta = "Javac, jar, debugging tools, javap",
                    AlternativaCorreta = false,
                    QuestoesId = 8
                },
                new Models.Alternativa
                {
                    Id = 24,
                    Resposta = "Java, javaw, libraries,rt.jar",
                    AlternativaCorreta = true,
                    QuestoesId = 8
                },

                new Models.Alternativa
                {
                    Id = 25,
                    Resposta = "Um valor nulo (void).",
                    AlternativaCorreta = false,
                    QuestoesId = 9
                },
                new Models.Alternativa
                {
                    Id = 26,
                    Resposta = "ser público (static).",
                    AlternativaCorreta = false,
                    QuestoesId = 9
                },
                new Models.Alternativa
                {
                    Id = 27,
                    Resposta = "Receber como parâmetro um array de string.",
                    AlternativaCorreta = true,
                    QuestoesId = 9
                },

                new Models.Alternativa
                {
                    Id = 28,
                    Resposta = "int salario;",
                    AlternativaCorreta = false,
                    QuestoesId = 10
                },
                new Models.Alternativa
                {
                    Id = 29,
                    Resposta = "int salário;",
                    AlternativaCorreta = true,
                    QuestoesId = 10
                },
                new Models.Alternativa
                {
                    Id = 30,
                    Resposta = "int _5minutos;",
                    AlternativaCorreta = false,
                    QuestoesId = 10
                },

                new Models.Alternativa
                {
                    Id = 31,
                    Resposta = "Um método de nomeação ",
                    AlternativaCorreta = false,
                    QuestoesId = 11
                },
                new Models.Alternativa
                {
                    Id = 32,
                    Resposta = "Uma porção de memória que armazena dados.",
                    AlternativaCorreta = true,
                    QuestoesId = 11
                },
                new Models.Alternativa
                {
                    Id = 33,
                    Resposta = "Uma variação de código ",
                    AlternativaCorreta = false,
                    QuestoesId = 11
                },

                new Models.Alternativa
                {
                    Id = 34,
                    Resposta = "Variáveis byte são do tipo numéricos inteiros.",
                    AlternativaCorreta = false,
                    QuestoesId = 12
                },
                new Models.Alternativa
                {
                    Id = 35,
                    Resposta = "Variáveis boolean são do tipo numéricos inteiros.",
                    AlternativaCorreta = true,
                    QuestoesId = 12
                },
                new Models.Alternativa
                {
                    Id = 36,
                    Resposta = "Variáveis float são numéricos com ponto flutuantes.",
                    AlternativaCorreta = false,
                    QuestoesId = 12
                },

                new Models.Alternativa
                {
                    Id = 19,
                    Resposta = "início – entrada - resultados - processamento - fim",
                    AlternativaCorreta = false,
                    QuestoesId = 13
                },
                new Models.Alternativa
                {
                    Id = 20,
                    Resposta = "início - variáveis – processamento – informações - fim",
                    AlternativaCorreta = false,
                    QuestoesId = 13
                },
                new Models.Alternativa
                {
                    Id = 21,
                    Resposta = "início – entrada – processamento – saida – fim",
                    AlternativaCorreta = true,
                    QuestoesId = 13
                },

                new Models.Alternativa
                {
                    Id = 22,
                    Resposta = "Os comandos serão executados na ordem que foram escritos",
                    AlternativaCorreta = false,
                    QuestoesId = 14
                },
                new Models.Alternativa
                {
                    Id = 23,
                    Resposta = "Os comandos serão escritos seguindo uma ordem de semântica",
                    AlternativaCorreta = false,
                    QuestoesId = 14
                },
                new Models.Alternativa
                {
                    Id = 24,
                    Resposta = "O algoritmo pode ser finalizado no meio do processo a qualquer momento",
                    AlternativaCorreta = true,
                    QuestoesId = 14
                },

                new Models.Alternativa
                {
                    Id = 25,
                    Resposta = "certo",
                    AlternativaCorreta = false,
                    QuestoesId = 15
                },
                new Models.Alternativa
                {
                    Id = 26,
                    Resposta = "errado",
                    AlternativaCorreta = true,
                    QuestoesId = 15
                },
                //new Models.Alternativa
                //{
                //    Id = 27,
                //    Resposta = "",
                //    AlternativaCorreta = true,
                //    QuestoesId = 15
                //},

                new Models.Alternativa
                {
                    Id = 28,
                    Resposta = "O if em java sempre será escrito como uma expressao boolean",
                    AlternativaCorreta = true,
                    QuestoesId = 16
                },
                new Models.Alternativa
                {
                    Id = 29,
                    Resposta = "O if em java sempre será escrito como uma expressao Integer",
                    AlternativaCorreta = false,
                    QuestoesId = 16
                },
                new Models.Alternativa
                {
                    Id = 30,
                    Resposta = "O if em java sempre será escrito como uma expressao String",
                    AlternativaCorreta = false,
                    QuestoesId = 16
                },

                new Models.Alternativa
                {
                    Id = 31,
                    Resposta = "o else só ocorrerá se o if for F",
                    AlternativaCorreta = true,
                    QuestoesId = 17
                },
                new Models.Alternativa
                {
                    Id = 32,
                    Resposta = "o else ocorrerá sempre após o if",
                    AlternativaCorreta = false,
                    QuestoesId = 17
                },
                new Models.Alternativa
                {
                    Id = 33,
                    Resposta = "o else só ocorrerá quando o if for V",
                    AlternativaCorreta = false,
                    QuestoesId = 17
                },

                new Models.Alternativa
                {
                    Id = 34,
                    Resposta = "Errado",
                    AlternativaCorreta = false,
                    QuestoesId = 18
                },
                new Models.Alternativa
                {
                    Id = 35,
                    Resposta = "Certo",
                    AlternativaCorreta = true,
                    QuestoesId = 18
                });
            //new Models.Alternativa
            //{
            //    Id = 36,
            //    Resposta = "Variáveis float são numéricos com ponto flutuantes.",
            //    AlternativaCorreta = false,
            //    QuestoesId = 18
            //}
        }
    }
}