using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StudentWebApi.Models
{
    public partial class SaxotempdbContext : DbContext
    {
        public SaxotempdbContext()
        {
        }

        public SaxotempdbContext(DbContextOptions<SaxotempdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DhrgStudentDetail> DhrgStudentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("server=unifiedclientregistration.db.sys.dom,4161;database=saxotempdb;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYS\\DHRG");

            modelBuilder.Entity<DhrgStudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId).HasName("PK__DhrgStud__32C52B9913012605");

                entity.Property(e => e.StudentId).ValueGeneratedNever();
                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Subject2).HasColumnName("subject2");
                entity.Property(e => e.Subject3).HasColumnName("subject3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
