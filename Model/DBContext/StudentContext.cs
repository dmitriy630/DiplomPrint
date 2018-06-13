using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DiplomPrint.Model.DBContext
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<StateAttestation> StateAttestation { get; set; }
        public DbSet<AdditionalInformation> AddInformation { get; set; }
        public DbSet<CourseWork> CourseWork { get; set; }
        public DbSet<Practice> PracticeWork { get; set; }
        public DbSet<Electives> Elective { get; set; }

        public StudentContext()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<StudentContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
