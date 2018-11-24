namespace StreamingModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llllkl : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "streamingService_ID" });
            CreateIndex("dbo.Movies", "StreamingService_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "StreamingService_ID" });
            CreateIndex("dbo.Movies", "streamingService_ID");
        }
    }
}
