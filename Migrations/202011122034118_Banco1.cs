namespace _30Code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banco1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cur_curso", "Curso_Id", "dbo.cur_curso");
            DropForeignKey("dbo.con_conteudo", "CursoId", "dbo.cur_curso");
            DropIndex("dbo.con_conteudo", new[] { "CursoId" });
            DropIndex("dbo.cur_curso", new[] { "Curso_Id" });
            DropColumn("dbo.con_conteudo", "CursoId");
            DropColumn("dbo.cur_curso", "Curso_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cur_curso", "Curso_Id", c => c.Int());
            AddColumn("dbo.con_conteudo", "CursoId", c => c.Int(nullable: false));
            CreateIndex("dbo.cur_curso", "Curso_Id");
            CreateIndex("dbo.con_conteudo", "CursoId");
            AddForeignKey("dbo.con_conteudo", "CursoId", "dbo.cur_curso", "cur_id", cascadeDelete: true);
            AddForeignKey("dbo.cur_curso", "Curso_Id", "dbo.cur_curso", "cur_id");
        }
    }
}
