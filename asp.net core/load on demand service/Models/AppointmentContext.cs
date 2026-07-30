using Microsoft.EntityFrameworkCore;

namespace ej2_core_schedule_app.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    Subject = "Meeting",
                    StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 0, 0),
                    EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 12, 0, 0),
                    Location = "Tamilnadu"
                }
            ); ;
        }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
