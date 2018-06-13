namespace DiplomPrint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassroomHours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ClassroomHours", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ClassroomHours");
        }
    }
}
