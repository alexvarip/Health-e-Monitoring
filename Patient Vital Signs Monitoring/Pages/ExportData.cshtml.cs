using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patient_Vital_Signs_Monitoring.Models;
using System.Text;

[Authorize]
public class ExportDataModel : PageModel
{
    private readonly IPatientRepository _repository;
    private readonly ILogger<ExportDataModel> _logger;
    private List<VitalSignsModel> _vitalSigns { get; set; }
    private List<PatientModel> _patientList { get; set; }


    public ExportDataModel(IPatientRepository repository, ILogger<ExportDataModel> logger)
    {
        _repository = repository;
        _logger = logger;
    }

   
    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            _patientList = (await _repository.GetAllPatients()).ToList();

            var csv = new StringBuilder();
            csv.AppendLine("PatientId,VitalSignId,Name,Age,Room,HeartRate,BloodPressure,OxygenSaturation");

            foreach (var p in _patientList)
            {
                _vitalSigns = (await _repository.GetAllVitalSignsAsync(p.PatientId)).ToList();
                foreach (var v in _vitalSigns)
                {
                    csv.AppendLine($"{p.PatientId},{v.VitalSignsId},{p.Name},{p.Age},{p.RoomNumber},{v.HeartRate},{v.BloodPressure},{v.OxygenSaturation}");
                }
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());

            _logger.LogInformation("CSV export completed. Total bytes: {Length}.", bytes.Length);

            return File(bytes, "text/csv", "VitalSignsExport.csv");
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Export operation was canceled.");
            return Content("Export was canceled.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error exporting data");
            return Content($"Error exporting data: {ex.Message}");
        }
    }

}