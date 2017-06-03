namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetAll4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "Country", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "membershipType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "membershipType", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "Country", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
