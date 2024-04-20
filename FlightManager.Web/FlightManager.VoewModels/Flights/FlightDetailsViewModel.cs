using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Flights
{
    public class FlightDetailsViewModel
    {
        public string Id { get; set; }

        public string DepartureTown { get; set; }

        public string ArrivalTown { get; set; }
        
        public string DepartureTime { get; set; }
        
        public string ArrivalTime { get; set; }
        
        public string PlaneType { get; set; }
        
        public string UniquePlaneNumber { get; set; }
        
        public string? PilotName { get; set; }
        
        public int RegularCapacity { get; set; }
        
        public int BusinessCapacity { get; set; }
    }
}
