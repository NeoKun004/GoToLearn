namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetAll5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
