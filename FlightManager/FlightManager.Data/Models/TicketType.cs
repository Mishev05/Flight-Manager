using FlightManager.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class TicketType
    {
        public TicketType()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
