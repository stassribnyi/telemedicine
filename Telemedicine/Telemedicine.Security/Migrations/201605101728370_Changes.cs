namespace Telemedicine.Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        ApplicationRole_Id = c.Int(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.ApplicationRole_Id)
                .ForeignKey("dbo.Doctors", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationUser_Id);

            AddColumn("dbo.Doctors", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "SecurityStamp", c => c.String());
            AddColumn("dbo.Doctors", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Doctors", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "AccessFailedCount", c => c.Int(nullable: false));

            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Doctors", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.Doctors");
            DropForeignKey("dbo.UserLogins", "ApplicationUser_Id", "dbo.Doctors");
            DropForeignKey("dbo.UserClaim", "ApplicationUser_Id", "dbo.Doctors");
            DropForeignKey("dbo.UserRoles", "ApplicationRole_Id", "dbo.Roles");

            DropColumn("dbo.Doctors", "EmailConfirmed");
            DropColumn("dbo.Doctors", "SecurityStamp");
            DropColumn("dbo.Doctors", "PhoneNumberConfirmed");
            DropColumn("dbo.Doctors", "TwoFactorEnabled");
            DropColumn("dbo.Doctors", "LockoutEndDateUtc");
            DropColumn("dbo.Doctors", "LockoutEnabled");
            DropColumn("dbo.Doctors", "AccessFailedCount");

            DropIndex("dbo.UserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "ApplicationRole_Id" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaim");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
