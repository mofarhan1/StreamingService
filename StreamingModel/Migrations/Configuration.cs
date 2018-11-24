namespace StreamingModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StreamingModel.StreamingDatabase.StreamingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StreamingModel.StreamingDatabase.StreamingContext";
        }

        protected override void Seed(StreamingModel.StreamingDatabase.StreamingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            
        }
    }
}
