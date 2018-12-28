namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Godine",
                c => new
                    {
                        GodineID = c.Int(nullable: false),
                        Opis = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.GodineID);
            
            CreateTable(
                "dbo.Odeljenja",
                c => new
                    {
                        OdeljenjaID = c.Int(nullable: false, identity: true),
                        GodineID = c.Int(nullable: false),
                        BrojOdeljenja = c.String(nullable: false, maxLength: 50),
                        SkolskaGodinaID = c.Int(nullable: false),
                        ProfesoriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdeljenjaID)
                .ForeignKey("dbo.Godine", t => t.GodineID, cascadeDelete: true)
                .ForeignKey("dbo.SkolskaGodina", t => t.SkolskaGodinaID, cascadeDelete: true)
                .ForeignKey("dbo.Profesori", t => t.ProfesoriID, cascadeDelete: true)
                .Index(t => t.GodineID)
                .Index(t => t.SkolskaGodinaID)
                .Index(t => t.ProfesoriID);
            
            CreateTable(
                "dbo.Profesori",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 50),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        KorisnickoIme = c.String(nullable: false, maxLength: 50),
                        Lozinka = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Predmeti",
                c => new
                    {
                        PredmetiID = c.Int(nullable: false),
                        NazivPredmeta = c.String(maxLength: 50),
                        GodineID = c.Int(nullable: false),
                        Redosled = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PredmetiID)
                .ForeignKey("dbo.Godine", t => t.GodineID, cascadeDelete: true)
                .Index(t => t.GodineID);
            
            CreateTable(
                "dbo.Prof_Predm",
                c => new
                    {
                        Prof_PredmID = c.Int(nullable: false, identity: true),
                        ProfesoriID = c.Int(nullable: false),
                        PredmetiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Prof_PredmID)
                .ForeignKey("dbo.Predmeti", t => t.PredmetiID, cascadeDelete: true)
                .ForeignKey("dbo.Profesori", t => t.ProfesoriID, cascadeDelete: true)
                .Index(t => t.ProfesoriID)
                .Index(t => t.PredmetiID);
            
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
                        Ime = c.String(nullable: false, maxLength: 50),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        Adresa = c.String(maxLength: 50),
                        DatumRodjenja = c.DateTime(nullable: false),
                        SkolskaGodinaID = c.Int(nullable: false),
                        RedBrUOdeljenju = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SkolskaGodina", t => t.SkolskaGodinaID, cascadeDelete: true)
                .Index(t => t.SkolskaGodinaID);
            
            CreateTable(
                "dbo.SkolskaGodina",
                c => new
                    {
                        SkolskaGodinaID = c.Int(nullable: false, identity: true),
                        Opis = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SkolskaGodinaID);
            
            CreateTable(
                "dbo.PredmetiProfesori",
                c => new
                    {
                        Predmeti_PredmetiID = c.Int(nullable: false),
                        Profesori_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Predmeti_PredmetiID, t.Profesori_ID })
                .ForeignKey("dbo.Predmeti", t => t.Predmeti_PredmetiID, cascadeDelete: true)
                .ForeignKey("dbo.Profesori", t => t.Profesori_ID, cascadeDelete: true)
                .Index(t => t.Predmeti_PredmetiID)
                .Index(t => t.Profesori_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Odeljenja", "ProfesoriID", "dbo.Profesori");
            DropForeignKey("dbo.Ucen_Predm_Ocena", "UceniciID", "dbo.Ucenici");
            DropForeignKey("dbo.Ucenici", "SkolskaGodinaID", "dbo.SkolskaGodina");
            DropForeignKey("dbo.Odeljenja", "SkolskaGodinaID", "dbo.SkolskaGodina");
            DropForeignKey("dbo.Ucen_Predm_Ocena", "PredmetiID", "dbo.Predmeti");
            DropForeignKey("dbo.PredmetiProfesori", "Profesori_ID", "dbo.Profesori");
            DropForeignKey("dbo.PredmetiProfesori", "Predmeti_PredmetiID", "dbo.Predmeti");
            DropForeignKey("dbo.Prof_Predm", "ProfesoriID", "dbo.Profesori");
            DropForeignKey("dbo.Prof_Predm", "PredmetiID", "dbo.Predmeti");
            DropForeignKey("dbo.Predmeti", "GodineID", "dbo.Godine");
            DropForeignKey("dbo.Odeljenja", "GodineID", "dbo.Godine");
            DropIndex("dbo.PredmetiProfesori", new[] { "Profesori_ID" });
            DropIndex("dbo.PredmetiProfesori", new[] { "Predmeti_PredmetiID" });
            DropIndex("dbo.Ucenici", new[] { "SkolskaGodinaID" });
            DropIndex("dbo.Ucen_Predm_Ocena", new[] { "UceniciID" });
            DropIndex("dbo.Ucen_Predm_Ocena", new[] { "PredmetiID" });
            DropIndex("dbo.Prof_Predm", new[] { "PredmetiID" });
            DropIndex("dbo.Prof_Predm", new[] { "ProfesoriID" });
            DropIndex("dbo.Predmeti", new[] { "GodineID" });
            DropIndex("dbo.Odeljenja", new[] { "ProfesoriID" });
            DropIndex("dbo.Odeljenja", new[] { "SkolskaGodinaID" });
            DropIndex("dbo.Odeljenja", new[] { "GodineID" });
            DropTable("dbo.PredmetiProfesori");
            DropTable("dbo.SkolskaGodina");
            DropTable("dbo.Ucenici");
            DropTable("dbo.Ucen_Predm_Ocena");
            DropTable("dbo.Prof_Predm");
            DropTable("dbo.Predmeti");
            DropTable("dbo.Profesori");
            DropTable("dbo.Odeljenja");
            DropTable("dbo.Godine");
        }
    }
}
