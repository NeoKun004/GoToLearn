namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Login", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Country", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Birthdate");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "Login");
        }
    }
}
