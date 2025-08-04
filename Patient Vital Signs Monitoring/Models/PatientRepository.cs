using Microsoft.EntityFrameworkCore;
using Patient_Vital_Signs_Monitoring.Data;
using System.Diagnostics;

namespace Patient_Vital_Signs_Monitoring.Models
{
    public class PatientRepository : IPatientRepository 
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /* Simulation Methods:
         *  Randomly create and add a new patient to database
         *  Randomly create and add new vital signs for a patient to database
        */

        public async Task<PatientModel> CreateRandomPatient()
        {
            var random = new Random();

            // Example names for random patient selection and creation
            var firstNames = new[] { "Alex", "Sam", "Chris", "Taylor", "Jordan", "Morgan", "Casey", "Jamie", "John" };
            var lastNames = new[] { "Lee", "Kim", "Patel", "Garcia", "Brown", "Nguyen", "Martinez", "Clark" };

            string name = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}";
            int age = random.Next(25, 100);
            int roomNumber = random.Next(104, 200);

           var newPatient = new PatientModel
            {
                PatientId = Guid.CreateVersion7(),
                Name = name,
                Age = age,
                RoomNumber = roomNumber
            };
            
            _dbContext.Patients.Add(newPatient);
            await _dbContext.SaveChangesAsync();

            return newPatient;
        }

        
        public async Task<VitalSignsModel> CreateVitalSigns(Guid patientId)
        {
            var random = new Random();
            int heartRate = random.Next(60, 130);
            int systolic = random.Next(90, 140);
            int diastolic = random.Next(60, 100);
            string bloodPressure = $"{systolic}/{diastolic}";
            int oxygenSaturation = random.Next(88, 100);

            var vitalSigns = new VitalSignsModel
            {
                PatientId = patientId,
                VitalSignsId = Guid.CreateVersion7(),
                HeartRate = heartRate,
                BloodPressure = bloodPressure,
                OxygenSaturation = oxygenSaturation,
            };

            _dbContext.VitalSigns.Add(vitalSigns);
            await _dbContext.SaveChangesAsync();

            return vitalSigns;
        }


        public async Task<PatientModel> GetPatientById(Guid id)
        {
            return await _dbContext.Patients.FindAsync(id);
        }


        public async Task<IEnumerable<PatientModel>> GetAllPatients()
        {
            return await _dbContext.Patients.AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<VitalSignsModel>> GetLatestVitalSignsAsync(Guid patientId)
        {
            // Fetch the latest vital signs record for a specific patient
            var latest = await _dbContext.VitalSigns
                .Where(vs => vs.PatientId == patientId)
                .OrderByDescending(vs => vs.VitalSignsId)
                .Take(4)
                .ToListAsync();

            return latest;
        }


        public async Task<IEnumerable<VitalSignsModel>> GetAllVitalSignsAsync(Guid patientId)
        {
            // Historical data view for the last 24 hours
            //return await _dbContext.VitalSigns.AsNoTracking().ToListAsync();

            var allVitalSigns = await _dbContext.VitalSigns
                .Where(vs => vs.PatientId == patientId)
                .OrderByDescending(vs => vs.VitalSignsId)
                .ToListAsync();

            return allVitalSigns;
        }
    }
}
