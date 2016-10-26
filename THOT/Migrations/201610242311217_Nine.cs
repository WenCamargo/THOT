namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answer", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Question", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Answer", "Description", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
