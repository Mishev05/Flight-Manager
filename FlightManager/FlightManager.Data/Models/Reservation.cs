using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public long PIN { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNum { get; set; }

        public string Nationality { get; set; }

        [Required]
        public string TicketType { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
