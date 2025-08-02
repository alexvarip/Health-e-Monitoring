namespace Patient_Vital_Signs_Monitoring.Models
{
    public interface IPatientRepository
    {
        Task<PatientModel> CreateRandomPatient();
        Task<VitalSignsModel> CreateVitalSigns(Guid patientId);
        Task<PatientModel> GetPatientById(Guid id);
        Task<IEnumerable<PatientModel>> GetAllPatients();
        Task<IEnumerable<VitalSignsModel>> GetLatestVitalSignsAsync(Guid patientId);
        Task<IEnumerable<VitalSignsModel>> GetAllVitalSignsAsync();
    }
}
