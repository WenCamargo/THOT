namespace THOT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentTests", "UserId", c => c.String());
            AlterColumn("dbo.StudentTests", "Grade", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentTests", "Grade", c => c.Double(nullable: false));
            AlterColumn("dbo.StudentTests", "UserId", c => c.Int(nullable: false));
        }
    }
}
