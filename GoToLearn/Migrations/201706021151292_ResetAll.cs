namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetAll : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Login", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Login", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
