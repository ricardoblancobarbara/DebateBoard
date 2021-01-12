namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebaterAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debater",
                c => new
                    {
                        DebaterId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.DebaterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Debater");
        }
    }
}
