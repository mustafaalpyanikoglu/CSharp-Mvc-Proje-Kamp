namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migedit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 1),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "RoleId", c => c.Int());
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "RoleId");
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 15));
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
            DropColumn("dbo.Admins", "RoleId");
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "AdminStatus");
            DropTable("dbo.Roles");
        }
    }
}
