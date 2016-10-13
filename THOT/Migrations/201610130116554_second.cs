namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Description = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Topic", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        UnitId = c.Int(nullable: false),
                        Number = c.String(maxLength: 50),
                        Name = c.String(maxLength: 250),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Number = c.String(maxLength: 10),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        AreaId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Area", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.Score",
                c => new
                    {
                        ScoreId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Grade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ScoreId)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Score", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.Topic", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Unit", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Subject", "AreaId", "dbo.Area");
            DropForeignKey("dbo.Question", "TestId", "dbo.Test");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropIndex("dbo.Score", new[] { "TestId" });
            DropIndex("dbo.Subject", new[] { "AreaId" });
            DropIndex("dbo.Unit", new[] { "SubjectId" });
            DropIndex("dbo.Topic", new[] { "UnitId" });
            DropIndex("dbo.Test", new[] { "TopicId" });
            DropIndex("dbo.Question", new[] { "TestId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.Score");
            DropTable("dbo.Area");
            DropTable("dbo.Subject");
            DropTable("dbo.Unit");
            DropTable("dbo.Topic");
            DropTable("dbo.Test");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
