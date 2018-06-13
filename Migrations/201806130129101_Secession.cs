namespace DiplomPrint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Secession", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Secession");
        }
    }
}
