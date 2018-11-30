namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImeIPrezime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ucenici", "Ime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Ucenici", "Prezime", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ucenici", "Prezime", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ucenici", "Ime", c => c.String(maxLength: 50));
        }
    }
}
