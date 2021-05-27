using SportsPro.Domain;

namespace SportsPro.App.Controllers
{
    internal class IncidentViewModel
    {
        public Incident ActiveIncident { get; set; }
        public Technician ActiveTechnician { get; set; }
        public object Incidents { get; set; }
        public object Technicians { get; set; }
        public object Customers { get; set; }
        public object Products { get; set; }
    }
}