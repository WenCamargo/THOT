namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentTestQuestionAnswers",
                c => new
                    {
                        StudentTestQuestionAnswerId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentTestQuestionAnswerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentTestQuestionAnswers");
        }
    }
}
