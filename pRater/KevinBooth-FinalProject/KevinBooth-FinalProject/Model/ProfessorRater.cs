namespace KevinBooth_FinalProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProfessorRater : DbContext
    {
        public ProfessorRater()
            : base("name=ProfessorRater")
        {
        }

        public virtual DbSet<PROFESSOR> PROFESSORs { get; set; }
        public virtual DbSet<PROFRATING> PROFRATINGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PROFESSOR>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<PROFESSOR>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<PROFESSOR>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<PROFESSOR>()
                .Property(e => e.ProfileImage)
                .IsUnicode(false);

            modelBuilder.Entity<PROFESSOR>()
                .HasMany(e => e.PROFRATINGs)
                .WithRequired(e => e.PROFESSOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROFRATING>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<PROFRATING>()
                .Property(e => e.ClassTaken)
                .IsUnicode(false);

            modelBuilder.Entity<PROFRATING>()
                .Property(e => e.GradeReceived)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
