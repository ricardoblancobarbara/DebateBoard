namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovingArticle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Article", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Article", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
