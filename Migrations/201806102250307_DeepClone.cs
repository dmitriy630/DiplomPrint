namespace DiplomPrint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeepClone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Student_StudentID", c => c.Int());
            CreateIndex("dbo.Students", "Student_StudentID");
            AddForeignKey("dbo.Students", "Student_StudentID", "dbo.Students", "StudentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Student_StudentID" });
            DropColumn("dbo.Students", "Student_StudentID");
        }
    }
}
