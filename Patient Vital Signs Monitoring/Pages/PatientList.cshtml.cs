using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patient_Vital_Signs_Monitoring.Models;


[Authorize]
public class PatientListModel : PageModel
{
    public List<PatientModel> Patients { get; set; }
    private readonly IPatientRepository _repository;

    public PatientListModel(IPatientRepository repository)
    {
        _repository = repository;
    }


    public void OnGet()
    {
        Patients = _repository.GetAllPatients().Result.ToList();
    }

}