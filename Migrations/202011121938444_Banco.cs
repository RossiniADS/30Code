namespace _30Code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.con_conteudo", "CursoId", c => c.Int(nullable: false));
            AddColumn("dbo.cur_curso", "Curso_Id", c => c.Int());
            CreateIndex("dbo.con_conteudo", "CursoId");
            CreateIndex("dbo.cur_curso", "Curso_Id");
            AddForeignKey("dbo.cur_curso", "Curso_Id", "dbo.cur_curso", "cur_id");
            AddForeignKey("dbo.con_conteudo", "CursoId", "dbo.cur_curso", "cur_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.con_conteudo", "CursoId", "dbo.cur_curso");
            DropForeignKey("dbo.cur_curso", "Curso_Id", "dbo.cur_curso");
            DropIndex("dbo.cur_curso", new[] { "Curso_Id" });
            DropIndex("dbo.con_conteudo", new[] { "CursoId" });
            DropColumn("dbo.cur_curso", "Curso_Id");
            DropColumn("dbo.con_conteudo", "CursoId");
        }
    }
}
