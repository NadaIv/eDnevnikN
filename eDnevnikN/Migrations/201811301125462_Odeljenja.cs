namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Odeljenja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Odeljenja",
                c => new
                    {
                        OdeljenjaID = c.Int(nullable: false, identity: true),
                        Razred = c.String(nullable: false, maxLength: 50),
                        BrojOdeljenja = c.String(nullable: false, maxLength: 50),
                        GodinaUpisa = c.DateTime(nullable: false),
                        ProfesoriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdeljenjaID)
                .ForeignKey("dbo.Profesori", t => t.ProfesoriID, cascadeDelete: true)
                .Index(t => t.ProfesoriID);
            
            AddColumn("dbo.Profesori", "Profesori_ID", c => c.Int());
            CreateIndex("dbo.Profesori", "Profesori_ID");
            AddForeignKey("dbo.Profesori", "Profesori_ID", "dbo.Profesori", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Odeljenja", "ProfesoriID", "dbo.Profesori");
            DropForeignKey("dbo.Profesori", "Profesori_ID", "dbo.Profesori");
            DropIndex("dbo.Profesori", new[] { "Profesori_ID" });
            DropIndex("dbo.Odeljenja", new[] { "ProfesoriID" });
            DropColumn("dbo.Profesori", "Profesori_ID");
            DropTable("dbo.Odeljenja");
        }
    }
}
