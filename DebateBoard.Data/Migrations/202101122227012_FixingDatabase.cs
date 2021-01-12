namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingDatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Article", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Article", "Category", c => c.String());
        }
    }
}
