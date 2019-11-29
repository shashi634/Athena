namespace Athena.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class DbContextAthena : DbContext
    {
        public DbContextAthena()
            : base("name=AthenaValutDbContext")
        {
        }

        public virtual DbSet<ExamCoupan> ExamCoupan { get; set; }
        public virtual DbSet<ExamFee> ExamFee { get; set; }
        public virtual DbSet<ExamResult> ExamResult { get; set; }
        public virtual DbSet<ExamSet> ExamSet { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrgQuestion> OrgQuestion { get; set; }
        public virtual DbSet<QuestionOption> QuestionOption { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }
        public virtual DbSet<UserLevel> UserLevel { get; set; }
        public virtual DbSet<UserParticipation> UserParticipation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamCoupan>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamCoupan>()
                .Property(e => e.ExamSetId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamCoupan>()
                .HasMany(e => e.UserParticipation)
                .WithRequired(e => e.ExamCoupan)
                .HasForeignKey(e => e.CoupanCodeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamFee>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamFee>()
                .Property(e => e.ExamSetId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamResult>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamResult>()
                .Property(e => e.ExamSetId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamResult>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamResult>()
                .Property(e => e.MarksObtained)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamSet>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamSet>()
                .Property(e => e.OrganizationId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExamSet>()
                .HasMany(e => e.ExamFee)
                .WithRequired(e => e.ExamSet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamSet>()
                .HasMany(e => e.ExamResult)
                .WithRequired(e => e.ExamSet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamSet>()
                .HasMany(e => e.UserAnswer)
                .WithRequired(e => e.ExamSet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamSet>()
                .HasMany(e => e.UserParticipation)
                .WithRequired(e => e.ExamSet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Organization>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrgQuestion)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.QuestionOption)
                .WithRequired(e => e.Organization)
                .HasForeignKey(e => e.QuestionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.UserLevel)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrgQuestion>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrgQuestion>()
                .Property(e => e.OrganizationId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrgQuestion>()
                .HasMany(e => e.UserAnswer)
                .WithRequired(e => e.OrgQuestion)
                .HasForeignKey(e => e.QuestionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionOption>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<QuestionOption>()
                .Property(e => e.QuestionId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<QuestionOption>()
                .HasMany(e => e.UserAnswer)
                .WithRequired(e => e.QuestionOption)
                .HasForeignKey(e => e.SelectedOptionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.OrgQuestion)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.OrganizationId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAnswer)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserParticipation)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAnswer>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAnswer>()
                .Property(e => e.ExamSetId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAnswer>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAnswer>()
                .Property(e => e.QuestionId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAnswer>()
                .Property(e => e.SelectedOptionId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserLevel>()
                .Property(e => e.OrganizationId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserParticipation>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserParticipation>()
                .Property(e => e.ExamSetId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserParticipation>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserParticipation>()
                .Property(e => e.CoupanCodeId)
                .HasPrecision(18, 0);
        }
    }
}
