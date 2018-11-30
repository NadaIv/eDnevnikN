namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profesori : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profesori");
        }
    }
}
