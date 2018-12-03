namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OdeljenjaGodinaUpisa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Odeljenja", "GodinaUpisa", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Odeljenja", "GodinaUpisa", c => c.DateTime(nullable: false));
        }
    }
}
