namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predmeti",
                c => new
                    {
                        PredmetiID = c.Int(nullable: false),
                        NazivPredmeta = c.String(),
                        Redosled = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PredmetiID);
            
            CreateTable(
                "dbo.Ucen_Predm_Ocena",
                c => new
                    {
                        Ucen_Predm_OcenaID = c.Int(nullable: false, identity: true),
                        PredmetiID = c.Int(nullable: false),
                        UceniciID = c.Int(nullable: false),
                        Ocene = c.Int(),
                        DatumOcenjivanja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ucen_Predm_OcenaID)
                .ForeignKey("dbo.Predmeti", t => t.PredmetiID, cascadeDelete: true)
                .ForeignKey("dbo.Ucenici", t => t.UceniciID, cascadeDelete: true)
                .Index(t => t.PredmetiID)
                .Index(t => t.UceniciID);
            
            CreateTable(
                "dbo.Ucenici",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Adresa = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        GodinaUpisa = c.DateTime(nullable: false),
                        RedBrUOdeljenju = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ucen_Predm_Ocena", "UceniciID", "dbo.Ucenici");
            DropForeignKey("dbo.Ucen_Predm_Ocena", "PredmetiID", "dbo.Predmeti");
            DropIndex("dbo.Ucen_Predm_Ocena", new[] { "UceniciID" });
            DropIndex("dbo.Ucen_Predm_Ocena", new[] { "PredmetiID" });
            DropTable("dbo.Ucenici");
            DropTable("dbo.Ucen_Predm_Ocena");
            DropTable("dbo.Predmeti");
        }
    }
}
