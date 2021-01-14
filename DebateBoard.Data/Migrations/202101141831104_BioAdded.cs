namespace DebateBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BioAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bio",
                c => new
                    {
                        BioId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.BioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bio");
        }
    }
}
