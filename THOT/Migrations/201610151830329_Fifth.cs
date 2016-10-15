namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstLastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondLastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "StudentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "StudentId");
            DropColumn("dbo.AspNetUsers", "SecondLastName");
            DropColumn("dbo.AspNetUsers", "FirstLastName");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
