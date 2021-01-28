namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bio", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Bio", "Biography", c => c.String(nullable: false));
            DropColumn("dbo.Bio", "Title");
            DropColumn("dbo.Bio", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bio", "Content", c => c.String(nullable: false));
            AddColumn("dbo.Bio", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Bio", "Biography");
            DropColumn("dbo.Bio", "Name");
        }
    }
}
