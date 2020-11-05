namespace _30Code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.alt_alternativas",
                c => new
                    {
                        alt_id = c.Int(nullable: false, identity: true),
                        alt_resposta = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        que_id = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        QuestaoId = c.Int(nullable: false),
                        Questoes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.alt_id)
                .ForeignKey("dbo.que_questoes", t => t.Questoes_Id);
            
            CreateTable(
                "dbo.que_questoes",
                c => new
                    {
                        que_id = c.Int(nullable: false, identity: true),
                        que_titulo = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        que_tipoQuestao = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        con_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.que_id)
                .ForeignKey("dbo.con_conteudo", t => t.con_id, cascadeDelete: true);
            
            CreateTable(
                "dbo.con_conteudo",
                c => new
                    {
                        con_id = c.Int(nullable: false, identity: true),
                        con_titulo = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        tip_id = c.Int(nullable: false),
                        mod_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.con_id)
                .ForeignKey("dbo.mod_modulo", t => t.mod_id, cascadeDelete: true)
                .ForeignKey("dbo.tip_tipo", t => t.tip_id, cascadeDelete: true);
            
            CreateTable(
                "dbo.Anexoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        DataPostagem = c.DateTime(nullable: false, precision: 0),
                        Url = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ConteudoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.con_conteudo", t => t.ConteudoId, cascadeDelete: true);
            
            CreateTable(
                "dbo.mod_modulo",
                c => new
                    {
                        mod_id = c.Int(nullable: false, identity: true),
                        mod_titulo = c.String(nullable: false, unicode: false),
                        cur_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.mod_id)
                .ForeignKey("dbo.cur_curso", t => t.cur_id, cascadeDelete: true);
            
            CreateTable(
                "dbo.cur_curso",
                c => new
                    {
                        cur_id = c.Int(nullable: false, identity: true),
                        cur_nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        cur_duracao = c.Double(nullable: false),
                        cur_url_imagem = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.cur_id);
            
            CreateTable(
                "dbo.tip_tipo",
                c => new
                    {
                        tip_id = c.Int(nullable: false, identity: true),
                        tip_tipo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.tip_id);
            
            CreateTable(
                "dbo.usu_usuario",
                c => new
                    {
                        usu_id = c.Int(nullable: false, identity: true),
                        usu_nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        usu_email = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        usu_senha = c.String(nullable: false, unicode: false),
                        usu_celular = c.String(unicode: false),
                        usu_nascimento = c.DateTime(precision: 0),
                        usu_urlImagem = c.String(maxLength: 100, storeType: "nvarchar"),
                        usu_tipoUsuario = c.Int(nullable: false),
                        usu_sexo = c.Int(nullable: false),
                        Hash = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.usu_id);
            
            CreateTable(
                "dbo.usu_usuario_has_cur_curso",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        usu_id = c.Int(nullable: false),
                        cur_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cur_curso", t => t.cur_id, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario", t => t.usu_id, cascadeDelete: true);
            
            CreateTable(
                "dbo.usuario_has_curso_has_conteudo",
                c => new
                    {
                        usuario_has_curso_has_conteudo_id = c.Int(nullable: false, identity: true),
                        dataConclusao = c.DateTime(nullable: false, precision: 0),
                        aproveitamento = c.String(nullable: false, maxLength: 4, storeType: "nvarchar"),
                        usuario_has_curso_id = c.Int(nullable: false),
                        con_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuario_has_curso_has_conteudo_id)
                .ForeignKey("dbo.con_conteudo", t => t.con_id, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario_has_cur_curso", t => t.usuario_has_curso_id, cascadeDelete: true);
            
            CreateTable(
                "dbo.usuario_has_curso_has_conteudo_has_questoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        resposta = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        aproveitamento = c.String(nullable: false, maxLength: 4, storeType: "nvarchar"),
                        usuario_has_curso_has_conteudo_id = c.Int(nullable: false),
                        que_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.que_questoes", t => t.que_id, cascadeDelete: true)
                .ForeignKey("dbo.usuario_has_curso_has_conteudo", t => t.usuario_has_curso_has_conteudo_id, cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario_has_curso_has_conteudo_has_questoes", "usuario_has_curso_has_conteudo_id", "dbo.usuario_has_curso_has_conteudo");
            DropForeignKey("dbo.usuario_has_curso_has_conteudo_has_questoes", "que_id", "dbo.que_questoes");
            DropForeignKey("dbo.usuario_has_curso_has_conteudo", "usuario_has_curso_id", "dbo.usu_usuario_has_cur_curso");
            DropForeignKey("dbo.usuario_has_curso_has_conteudo", "con_id", "dbo.con_conteudo");
            DropForeignKey("dbo.usu_usuario_has_cur_curso", "usu_id", "dbo.usu_usuario");
            DropForeignKey("dbo.usu_usuario_has_cur_curso", "cur_id", "dbo.cur_curso");
            DropForeignKey("dbo.alt_alternativas", "Questoes_Id", "dbo.que_questoes");
            DropForeignKey("dbo.que_questoes", "con_id", "dbo.con_conteudo");
            DropForeignKey("dbo.con_conteudo", "tip_id", "dbo.tip_tipo");
            DropForeignKey("dbo.mod_modulo", "cur_id", "dbo.cur_curso");
            DropForeignKey("dbo.con_conteudo", "mod_id", "dbo.mod_modulo");
            DropForeignKey("dbo.Anexoes", "ConteudoId", "dbo.con_conteudo");
            DropIndex("dbo.usuario_has_curso_has_conteudo_has_questoes", new[] { "que_id" });
            DropIndex("dbo.usuario_has_curso_has_conteudo_has_questoes", new[] { "usuario_has_curso_has_conteudo_id" });
            DropIndex("dbo.usuario_has_curso_has_conteudo", new[] { "con_id" });
            DropIndex("dbo.usuario_has_curso_has_conteudo", new[] { "usuario_has_curso_id" });
            DropIndex("dbo.usu_usuario_has_cur_curso", new[] { "cur_id" });
            DropIndex("dbo.usu_usuario_has_cur_curso", new[] { "usu_id" });
            DropIndex("dbo.mod_modulo", new[] { "cur_id" });
            DropIndex("dbo.Anexoes", new[] { "ConteudoId" });
            DropIndex("dbo.con_conteudo", new[] { "mod_id" });
            DropIndex("dbo.con_conteudo", new[] { "tip_id" });
            DropIndex("dbo.que_questoes", new[] { "con_id" });
            DropIndex("dbo.alt_alternativas", new[] { "Questoes_Id" });
            DropTable("dbo.usuario_has_curso_has_conteudo_has_questoes");
            DropTable("dbo.usuario_has_curso_has_conteudo");
            DropTable("dbo.usu_usuario_has_cur_curso");
            DropTable("dbo.usu_usuario");
            DropTable("dbo.tip_tipo");
            DropTable("dbo.cur_curso");
            DropTable("dbo.mod_modulo");
            DropTable("dbo.Anexoes");
            DropTable("dbo.con_conteudo");
            DropTable("dbo.que_questoes");
            DropTable("dbo.alt_alternativas");
        }
    }
}
