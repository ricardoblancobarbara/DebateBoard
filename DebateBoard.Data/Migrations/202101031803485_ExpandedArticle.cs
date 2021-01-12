namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandedArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "Category", c => c.String());
            AddColumn("dbo.Article", "Subject", c => c.String());
            AddColumn("dbo.Article", "SubTitle", c => c.String(nullable: false));
            AddColumn("dbo.Article", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Article", "Author");
            DropColumn("dbo.Article", "SubTitle");
            DropColumn("dbo.Article", "Subject");
            DropColumn("dbo.Article", "Category");
        }
    }
}
