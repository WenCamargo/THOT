namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eight : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentTests",
                c => new
                    {
                        StudentTestId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        Grade = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentTestId)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentTests", "TestId", "dbo.Test");
            DropIndex("dbo.StudentTests", new[] { "TestId" });
            DropTable("dbo.StudentTests");
        }
    }
}
