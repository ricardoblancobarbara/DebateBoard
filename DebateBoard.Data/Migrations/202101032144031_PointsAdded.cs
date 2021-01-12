namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PointsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Article", "Points");
        }
    }
}
