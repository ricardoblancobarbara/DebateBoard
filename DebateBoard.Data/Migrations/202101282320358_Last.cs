namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Article", "ApplicationUser_Id");
            AddForeignKey("dbo.Article", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Article", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Article", "ApplicationUser_Id");
        }
    }
}
