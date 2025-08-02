using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patient_Vital_Signs_Monitoring.Models;

namespace Patient_Vital_Signs_Monitoring.Pages
{
    public class MonitorVitalsModel : PageModel
    {
        private readonly IPatientRepository _repository;
        public VitalSignsModel VitalSigns { get; set; }
        public List<VitalSignsModel> signs { get; set; }


        public MonitorVitalsModel(IPatientRepository repository)
        {
            _repository = repository;
        }


        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }


        public void OnGet()
        {
            signs = _repository.GetLatestVitalSignsAsync(Id).Result.ToList();
        }

    }
}