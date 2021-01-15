namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BioAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bio", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bio", "Id");
            AddForeignKey("dbo.Bio", "Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bio", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Bio", new[] { "Id" });
            DropColumn("dbo.Bio", "Id");
        }
    }
}
