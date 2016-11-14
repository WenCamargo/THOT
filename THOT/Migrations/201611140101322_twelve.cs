namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twelve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "SelectAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "SelectAnswer");
        }
    }
}
