namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FOE", c => c.String(maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Level", c => c.String(maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Diploma", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Diploma");
            DropColumn("dbo.AspNetUsers", "Level");
            DropColumn("dbo.AspNetUsers", "FOE");
        }
    }
}
