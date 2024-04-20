using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Flights
{
    public class EditFlightViewModel
    {
        public string Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string ArrivalTown { get; set; }
        public string? PilotName { get; set; }

    }
}
