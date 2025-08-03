using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patient_Vital_Signs_Monitoring.Models;
using System.Text;

[Authorize]
public class ExportDataModel : PageModel
{
    private readonly IPatientRepository _repository;
    private List<VitalSignsModel> vitalSigns { get; set; }
    public List<PatientModel> patientList { get; set; }


    public ExportDataModel(IPatientRepository repository)
    {
        _repository = repository;

    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }


    public async Task<IActionResult> OnGetAsync()
    {
        patientList = (await _repository.GetAllPatients()).ToList();

        var csv = new StringBuilder();

        // CSV Header
        csv.AppendLine("PatientId,VitalSignId,Name,Age,Room,HeartRate,BloodPressure,OxygenSaturation");

        // Fetch all vital signs for each patient
        foreach (var p in patientList)
        {
            vitalSigns = (await _repository.GetAllVitalSignsAsync(p.PatientId)).ToList();

            foreach (var v in vitalSigns)
            {
                csv.AppendLine($"{p.PatientId},{v.VitalSignsId},{p.Name},{p.Age},{p.RoomNumber},{v.HeartRate},{v.BloodPressure},{v.OxygenSaturation}");
            }
        }

        var bytes = Encoding.UTF8.GetBytes(csv.ToString());
        return File(bytes, "text/csv", "VitalSignsExport.csv");
    }

}