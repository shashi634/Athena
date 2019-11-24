using System.Data.Entity;

namespace Athena.Models
{
    public partial class AthenaVaultContext : DbContext
    {
        public AthenaVaultContext(): base("name=AthenaValutDbContext")
        {
        }

        public DbSet<ExamCoupan> ExamCoupan { get; set; }
        public DbSet<ExamFee> ExamFee { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }
        public DbSet<ExamSet> ExamSet { get; set; }
        public DbSet<OrgQuestion> OrgQuestion { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<QuestionOption> QuestionOption { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }
        public DbSet<UserLevel> UserLevel { get; set; }
        public DbSet<UserParticipation> UserParticipation { get; set; }
    }
}
