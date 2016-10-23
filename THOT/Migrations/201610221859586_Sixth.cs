namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answer", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Question", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Test", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topic", "Number", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topic", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Topic", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Unit", "Number", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Unit", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Subject", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Area", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Area", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Subject", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Unit", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Unit", "Number", c => c.String(maxLength: 10));
            AlterColumn("dbo.Topic", "Content", c => c.String());
            AlterColumn("dbo.Topic", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Topic", "Number", c => c.String(maxLength: 50));
            AlterColumn("dbo.Test", "Name", c => c.String());
            AlterColumn("dbo.Question", "Description", c => c.String());
            AlterColumn("dbo.Answer", "Description", c => c.String());
        }
    }
}
