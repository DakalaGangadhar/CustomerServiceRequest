using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Common.Models
{
    public partial class customerserviceDBContext : DbContext
    {
        public customerserviceDBContext()
        {
        }

        public customerserviceDBContext(DbContextOptions<customerserviceDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<ServiceRequestCategorie> ServiceRequestCategories { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<ServiceRequestAssign> ServiceRequestAssigns { get; set; }
        public virtual DbSet<ServiceRequestStatu> ServiceRequestStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET854;Initial Catalog=customerserviceDB;User ID=sa;Password=pass@word1");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
