using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Data.Configurations;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class ApplicationDbContext: DbContext
    {
        //override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=HospitalDb;Trusted_Connection=True;TrustServerCertificate=true;");
        //}
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.DoctorId });
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(e => e.PatientId);
                entity.HasOne(e => e.Doctor)
                      .WithMany(d => d.Appointments)
                      .HasForeignKey(e => e.DoctorId);
                entity.HasQueryFilter(a => !a.Patient.IsDeleted);
            });

            //modelBuilder.ApplyConfiguration(new PatientConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
