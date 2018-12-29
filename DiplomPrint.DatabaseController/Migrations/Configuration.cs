namespace DiplomPrint.DatabaseController.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomPrint.DatabaseController.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            try
            {
                var dbMigrator = new DbMigrator(this);

                var pendingMigrationExist = dbMigrator.GetPendingMigrations().Any();

                if (pendingMigrationExist)
                    dbMigrator.Update();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void Seed(DiplomPrint.DatabaseController.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
