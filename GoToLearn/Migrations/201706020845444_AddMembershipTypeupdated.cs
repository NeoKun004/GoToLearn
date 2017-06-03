namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeupdated : DbMigration
    {
        public override void Up()
        {
        
            AddColumn("dbo.AspNetUsers", "MembershipType", c => c.String(maxLength: 255));
          
        }
        
        public override void Down()
        {
           
        }
    }
}
