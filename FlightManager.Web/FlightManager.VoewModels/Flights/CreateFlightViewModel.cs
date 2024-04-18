using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Flights
{
    public class CreateFlightViewModel
    {
        public string DepartureTown { get; set; }
        public string ArrivalTown { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string PlaneType { get; set; }
        public string UniquePlaneNumber { get; set; }
        public string PilotName { get; set; }
        public int RegularCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public List<string> Pilots { get; set; } = new List<string>();
    }
}
