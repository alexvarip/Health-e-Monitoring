using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patient_Vital_Signs_Monitoring.Models;

public class SimulationModel : PageModel
{
    private readonly IPatientRepository _repository;
    public PatientModel Patient { get; set; }
    public VitalSignsModel VitalSigns { get; set; }


    public SimulationModel(IPatientRepository repo)
    {
        _repository = repo;
    }


    //[BindProperty(SupportsGet = true)]
    //public Guid Id { get; set; }


    public IActionResult OnPostCreatePatient()
    {
        Patient = _repository.CreateRandomPatient().Result;

        VitalSigns = _repository.CreateVitalSigns(Patient.PatientId).Result;

        return RedirectToPage("/PatientList");
    }


    public IActionResult OnPostCreateOnlyVitalSigns()
    {
        // Get all patients
        var patientsTask = _repository.GetAllPatients();
        patientsTask.Wait();
        var patients = patientsTask.Result.ToList();

        if (patients.Count == 0)
        {
            // Handle case where no patients exist
            return RedirectToPage("/PatientList");
        }

        // Select a random patient
        var random = new Random();
        var randomPatient = patients[random.Next(patients.Count)];

        // Create vital signs for the random patient
        VitalSigns = _repository.CreateVitalSigns(randomPatient.PatientId).Result;

        return RedirectToPage(pageName: "/PatientDetails", new { id = VitalSigns.PatientId });
    }

}