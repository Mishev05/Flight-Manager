using FlightManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Reservations
{
    public class IndexReservationViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string FligthInfo { get; set; }
        public Flight? Flight { get; set; }
        public User? User { get; set; }
    }
}
