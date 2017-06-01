namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateFieldUpdated : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Fields (Id, Name) VALUES (1, 'Design')");
            Sql("INSERT INTO Fields (Id, Name) VALUES (2, 'Development')");
            Sql("INSERT INTO Fields (Id, Name) VALUES (3, 'IT&Software')");
            Sql("INSERT INTO Fields (Id, Name) VALUES (4, 'Business')");
            Sql("INSERT INTO Fields (Id, Name) VALUES (5, 'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
