namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tthirteen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentTestQuestionAnswers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentTestQuestionAnswers", "UserId");
        }
    }
}
