namespace GoToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        VideoConferenceId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VideoConferences", t => t.VideoConferenceId_Id)
                .Index(t => t.VideoConferenceId_Id);
            
            CreateTable(
                "dbo.VideoConferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConferenceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Learners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Name = c.String(nullable: false, maxLength: 255),
                        Sex = c.String(),
                        Country = c.String(),
                        Level = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Birthdate = c.DateTime(),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Name = c.String(nullable: false, maxLength: 255),
                        Sex = c.String(),
                        Country = c.String(),
                        Diploma = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        FieldId = c.Byte(nullable: false),
                        Birthdate = c.DateTime(),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        FieldId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        TrainingDate = c.DateTime(nullable: false),
                        Level = c.String(),
                        Discription = c.String(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainings", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Trainers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Learners", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.ChatMessages", "VideoConferenceId_Id", "dbo.VideoConferences");
            DropIndex("dbo.Trainings", new[] { "FieldId" });
            DropIndex("dbo.Trainers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Learners", new[] { "MembershipTypeId" });
            DropIndex("dbo.ChatMessages", new[] { "VideoConferenceId_Id" });
            DropTable("dbo.Trainings");
            DropTable("dbo.Trainers");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Learners");
            DropTable("dbo.Fields");
            DropTable("dbo.VideoConferences");
            DropTable("dbo.ChatMessages");
        }
    }
}
