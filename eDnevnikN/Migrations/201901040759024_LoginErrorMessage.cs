namespace eDnevnikN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginErrorMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profesori", "LoginErrorMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profesori", "LoginErrorMessage");
        }
    }
}
