using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DiplomPrint.DatabaseController
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new DiplomPrintCreation());
        }
    }

    internal class DiplomPrintCreation : MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>
    {

    }

    #region DbSets
    #endregion
}
