using System.ComponentModel.DataAnnotations;

namespace Patient_Vital_Signs_Monitoring.Models
{
    public class VitalSignsModel
    {
        [Key]
        [Required]
        public Guid VitalSignsId { get; init; }

        [Required]
        public int HeartRate { get; set; }
        
        [Required]
        public required string BloodPressure { get; set; }
        
        [Required]
        public int OxygenSaturation { get; set; }


        // Foreign key to Patient
        public Guid PatientId { get; set; }
        public PatientModel Patient { get; set; }

    }
} 