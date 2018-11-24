namespace StreamingModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggjg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "is_following", c => c.Boolean(nullable: false));
            DropColumn("dbo.Ratings", "following");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "following", c => c.Boolean(nullable: false));
            DropColumn("dbo.Ratings", "is_following");
        }
    }
}
