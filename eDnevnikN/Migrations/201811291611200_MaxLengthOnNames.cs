namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predmeti", "NazivPredmeta", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ucenici", "Ime", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ucenici", "Prezime", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ucenici", "Adresa", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ucenici", "Adresa", c => c.String());
            AlterColumn("dbo.Ucenici", "Prezime", c => c.String());
            AlterColumn("dbo.Ucenici", "Ime", c => c.String());
            AlterColumn("dbo.Predmeti", "NazivPredmeta", c => c.String());
        }
    }
}
