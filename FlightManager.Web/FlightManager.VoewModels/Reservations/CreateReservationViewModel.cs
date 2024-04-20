using FlightManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Reservations
{
    public class CreateReservationViewModel
    {
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UCN { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserId { get; set; }
        public string? Nationality { get; set; }
        public string TicketType { get; set; }
        public string FlightId { get; set; }
        public Flight? Flight { get; set; }

    }
}
