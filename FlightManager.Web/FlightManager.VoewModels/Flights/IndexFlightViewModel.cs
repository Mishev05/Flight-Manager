using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Flights
{
    public class IndexFlightViewModel
    {
        public string Id { get; set; }
        public string DepartureFrom { get; set; }
        public string ArrivalTo { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
