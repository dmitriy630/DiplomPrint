namespace DiplomPrint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassroomHoursString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "ClassroomHours", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "ClassroomHours", c => c.Int(nullable: false));
        }
    }
}
