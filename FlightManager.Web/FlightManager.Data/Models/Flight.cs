using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class Flight
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();
        public string DepartureTown { get; set; }
        public string ArrivalTown { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string PlaneType { get; set; }
        public string UniquePlaneNumber { get; set; }
        public string?  PilotName { get; set; }
        public int PlaneRegularCapacity { get; set; }
        public int PlaneBusinessCapacity { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }=new List<Reservation>();
    }
}
