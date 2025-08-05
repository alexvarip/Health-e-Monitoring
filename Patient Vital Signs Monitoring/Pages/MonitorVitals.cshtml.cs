using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Patient_Vital_Signs_Monitoring.Hubs;
using Patient_Vital_Signs_Monitoring.Models;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Patient_Vital_Signs_Monitoring.Pages
{
    [IgnoreAntiforgeryToken]
    public class MonitorVitalsModel : PageModel
    {
        private readonly IPatientRepository _repository;
        private readonly IHubContext<VitalsHub> _hubContext;
        private readonly ILogger<MonitorVitalsModel> _logger;

        public VitalSignsModel VitalSigns { get; set; }
        public List<VitalSignsModel> signs { get; set; }
        public PatientModel Patient { get; set; }

        public MonitorVitalsModel(IPatientRepository repository, IHubContext<VitalsHub> hubContext, ILogger<MonitorVitalsModel> logger)
        {
            _repository = repository;
            _hubContext = hubContext;
            _logger = logger;
        }


        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        // TODO : Add Historical data view for the last 24 hours in monitoring mode
        //        as Progressive Line With Easing in chart.js

        public void OnGet()
        {
            signs = _repository.GetAllVitalSignsAsync(Id).Result
                    .OrderBy(s => s.Timestamp)
                    .Select(s => { s.Timestamp = DateTime.SpecifyKind(s.Timestamp, DateTimeKind.Utc); return s; })
                    .ToList();
            Patient = _repository.GetPatientById(Id).Result;
        }

        /// <summary>
        /// Generates a new vital sign for the selected patient, broadcasts it to all SignalR clients,
        /// logs the broadcast event, and returns the new vital sign as JSON.
        /// In order to display current vital signs on chart and simulate live updates 
        /// without page refresh, we want to generate a new vital sign for the selected
        /// patient at intervals. This should work only in monitoring mode, for simulation
        /// purposes, loading less unecessary data entries to the database.
        /// </summary>
        /// <returns>The newly generated vital sign as a JSON result.</returns>
        public async Task<IActionResult> OnPostBroadcastVitalSignAsync()
        {
            var newSign = await _repository.CreateVitalSigns(Id);

            _logger.LogInformation("Broadcasting new vital sign for patient {PatientId}", Id);

            await _hubContext.Clients.All.SendAsync("ReceiveVitalSign", newSign);

            return new JsonResult(newSign);
        }


        public async Task<IActionResult> OnGetHistorical24hAsync()
        {
            var now = DateTime.UtcNow;
            var last24h = now.AddHours(-24);

            var historicalSigns = (await _repository.GetAllVitalSignsAsync(Id))
                .Where(s => s.Timestamp >= last24h && s.Timestamp <= now)
                .OrderBy(s => s.Timestamp)
                .ToList();

            return new JsonResult(historicalSigns);
        }

    }
}