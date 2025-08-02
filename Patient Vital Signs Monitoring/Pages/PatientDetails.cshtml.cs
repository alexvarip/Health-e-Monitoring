using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patient_Vital_Signs_Monitoring.Models;

public class PatientDetailsModel : PageModel
{
    private readonly IPatientRepository _repository;
    public PatientModel Patient { get; set; }
    public VitalSignsModel VitalSigns { get; set; }
    public List<VitalSignsModel> signs { get; set; }


    public PatientDetailsModel(IPatientRepository repository)
    {
        _repository = repository;
    }


    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }


    public IActionResult OnPostCreateVitals()
    {
        VitalSigns = _repository.CreateVitalSigns(Id).Result;

        TempData["SuccessMessage"] = $"Vital signs with ID: <strong>{VitalSigns.VitalSignsId}</strong> posted successfully for patient ID: <strong>{Id}</strong>.";
        return RedirectToPage(pageName: "/PatientDetails", new { id = Id });
    }


    public void OnGet()
    {
        var result = _repository.GetPatientById(Id);
        Patient = result.Result;

        signs = _repository.GetLatestVitalSignsAsync(Id).Result.ToList();

    }


    public static string GetHeartRateStatus(int heartRate)
    {
        if (heartRate > 120) return "Critical";
        if (heartRate > 100 && heartRate <= 120) return "Warning";
        if (heartRate >= 60 && heartRate <= 100) return "Normal";
        return "Critical"; // Below 60 is also critical
    }

    public static string GetOxygenSaturationStatus(int oxygenSaturation)
    {
        if (oxygenSaturation < 90) return "Critical";
        if (oxygenSaturation < 95 && oxygenSaturation >= 90) return "Warning";
        return "Normal"; // 95 and above
    }

    // Blood Pressure: 90/60-119/79 (Normal), 120-139/80-89 (Warning), >139/>90 (Critical)
    public static string GetBloodPressureStatus(string bloodPressure)
    {
        var parts = bloodPressure.Split('/');
        if (parts.Length != 2) return "Critical";
        if (int.TryParse(parts[0], out int systolic) && int.TryParse(parts[1], out int diastolic))
        {
            // Critical: Either systolic > 139 or diastolic > 90, or either below 90/60
            if (systolic > 139 || diastolic > 90 || systolic < 90 || diastolic < 60)
                return "Critical";
            // Warning: Either systolic 120-139 or diastolic 80-89
            if ((systolic >= 120 && systolic <= 139) || (diastolic >= 80 && diastolic <= 89))
                return "Warning";
            // Normal: systolic 90-119 and diastolic 60-79
            if (systolic >= 90 && systolic <= 119 && diastolic >= 60 && diastolic <= 79)
                return "Normal";
            // If not matching any, treat as critical
            return "Critical";
        }
        return "Critical";
    }


}