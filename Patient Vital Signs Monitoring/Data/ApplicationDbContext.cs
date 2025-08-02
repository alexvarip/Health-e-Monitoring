using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Patient_Vital_Signs_Monitoring.Models;

namespace Patient_Vital_Signs_Monitoring.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<VitalSignsModel> VitalSigns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PatientModel>().HasData(
            new PatientModel
            {
                PatientId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                Name = "John Doe",
                Age = 45,
                RoomNumber = 101
            },
                new PatientModel
                {
                    PatientId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa2"),
                    Name = "Jane Smith",
                    Age = 32,
                    RoomNumber = 102
                },
                new PatientModel
                {
                    PatientId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa3"),
                    Name = "Bob Johnson",
                    Age = 67,
                    RoomNumber = 103
                }
            );


            modelBuilder.Entity<VitalSignsModel>().HasData(
            new VitalSignsModel
            {
                VitalSignsId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                HeartRate = 72,
                BloodPressure = "120/80",
                OxygenSaturation = 98,
                PatientId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa1")
            },
            new VitalSignsModel
            {
                VitalSignsId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa2"),
                HeartRate = 80,
                BloodPressure = "130/85",
                OxygenSaturation = 97,
                PatientId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa2")
            },
            new VitalSignsModel
            {
                VitalSignsId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa3"),
                HeartRate = 65,
                BloodPressure = "110/75",
                OxygenSaturation = 100,
                PatientId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa3")
            }
        );


        }
    }
}
