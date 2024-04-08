using FlightManager.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Data.Models
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        [Key]
        public int PlaneId { get; set; }

        [Required]
        public string DestinationFrom { get; set; }

        [Required]
        public string DestinationTo { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public string PlaneType { get; set; }

        [Required]
        public int UniquePlaneNumber { get; set; }

        public string PilotName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public int PassengersCapacity { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public int BusinessClassCapacity { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
