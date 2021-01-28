namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Article", "AuthorId", "dbo.ApplicationUser");
            DropIndex("dbo.Article", new[] { "AuthorId" });
            AlterColumn("dbo.Article", "AuthorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Article", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Article", "AuthorId");
            AddForeignKey("dbo.Article", "AuthorId", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
