namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fields", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fields", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
