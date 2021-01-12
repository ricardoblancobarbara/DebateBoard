namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "AuthorId", c => c.Guid(nullable: false));
            DropColumn("dbo.Article", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Article", "Author", c => c.String());
            DropColumn("dbo.Article", "AuthorId");
        }
    }
}
