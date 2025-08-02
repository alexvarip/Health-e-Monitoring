using System.ComponentModel.DataAnnotations;

namespace Patient_Vital_Signs_Monitoring.Models
{
    public class PatientModel
    {
        [Key]
        public Guid PatientId { get; init; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 130, ErrorMessage = "Age must be between 0 and 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Room number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Room number must be a positive number.")]
        public int RoomNumber { get; set; }

        public List<PatientModel> Patients { get; set; }
    }
}


