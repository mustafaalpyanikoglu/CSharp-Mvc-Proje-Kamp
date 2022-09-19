﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nessage_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Trash");
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
