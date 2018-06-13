namespace DiplomPrint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Install : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInformations",
                c => new
                    {
                        InformationID = c.Int(nullable: false, identity: true),
                        Information = c.String(maxLength: 2000),
                        addInfo_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.InformationID)
                .ForeignKey("dbo.Students", t => t.addInfo_StudentID)
                .Index(t => t.addInfo_StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        PreviousLevelEducation = c.String(maxLength: 265),
                        RegistrationNumber = c.Int(nullable: false),
                        ExtraditionDate = c.DateTime(nullable: false),
                        ExcellentAttribute = c.Boolean(nullable: false),
                        DiplomSeries = c.Int(nullable: false),
                        DiplomNumber = c.Int(nullable: false),
                        AttachmentSeries = c.Int(nullable: false),
                        AttachmentNumber = c.Int(nullable: false),
                        DecisionDate = c.DateTime(nullable: false),
                        Qualification = c.String(nullable: false),
                        Specialty = c.String(nullable: false),
                        Lifetime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.CourseWorks",
                c => new
                    {
                        CourseWorkID = c.Int(nullable: false, identity: true),
                        CourseWorkName = c.String(nullable: false),
                        Rating = c.String(nullable: false),
                        course_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseWorkID)
                .ForeignKey("dbo.Students", t => t.course_StudentID)
                .Index(t => t.course_StudentID);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        DisciplineID = c.Int(nullable: false, identity: true),
                        DisciplineName = c.String(nullable: false),
                        QuantityHours = c.Int(nullable: false),
                        Rating = c.String(nullable: false),
                        discipline_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.DisciplineID)
                .ForeignKey("dbo.Students", t => t.discipline_StudentID)
                .Index(t => t.discipline_StudentID);
            
            CreateTable(
                "dbo.Electives",
                c => new
                    {
                        ElectivesID = c.Int(nullable: false, identity: true),
                        ElectivesName = c.String(nullable: false),
                        QuantityHours = c.Int(nullable: false),
                        Rating = c.String(nullable: false),
                        elective_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.ElectivesID)
                .ForeignKey("dbo.Students", t => t.elective_StudentID)
                .Index(t => t.elective_StudentID);
            
            CreateTable(
                "dbo.Practices",
                c => new
                    {
                        PracticeID = c.Int(nullable: false, identity: true),
                        PracticeName = c.String(nullable: false),
                        QuantityWeeks = c.Int(nullable: false),
                        Rating = c.String(nullable: false),
                        practice_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.PracticeID)
                .ForeignKey("dbo.Students", t => t.practice_StudentID)
                .Index(t => t.practice_StudentID);
            
            CreateTable(
                "dbo.StateAttestations",
                c => new
                    {
                        StateAttestationID = c.Int(nullable: false, identity: true),
                        StateAttestationName = c.String(nullable: false),
                        QuantityWeeks = c.Int(nullable: false),
                        Rating = c.String(nullable: false),
                        stateAtt_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.StateAttestationID)
                .ForeignKey("dbo.Students", t => t.stateAtt_StudentID)
                .Index(t => t.stateAtt_StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalInformations", "addInfo_StudentID", "dbo.Students");
            DropForeignKey("dbo.StateAttestations", "stateAtt_StudentID", "dbo.Students");
            DropForeignKey("dbo.Practices", "practice_StudentID", "dbo.Students");
            DropForeignKey("dbo.Electives", "elective_StudentID", "dbo.Students");
            DropForeignKey("dbo.Disciplines", "discipline_StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseWorks", "course_StudentID", "dbo.Students");
            DropIndex("dbo.StateAttestations", new[] { "stateAtt_StudentID" });
            DropIndex("dbo.Practices", new[] { "practice_StudentID" });
            DropIndex("dbo.Electives", new[] { "elective_StudentID" });
            DropIndex("dbo.Disciplines", new[] { "discipline_StudentID" });
            DropIndex("dbo.CourseWorks", new[] { "course_StudentID" });
            DropIndex("dbo.AdditionalInformations", new[] { "addInfo_StudentID" });
            DropTable("dbo.StateAttestations");
            DropTable("dbo.Practices");
            DropTable("dbo.Electives");
            DropTable("dbo.Disciplines");
            DropTable("dbo.CourseWorks");
            DropTable("dbo.Students");
            DropTable("dbo.AdditionalInformations");
        }
    }
}
