using FlightManager.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Reservations
{
    public class IndexReservationsViewModel : PagingViewModel
    {
        public IndexReservationsViewModel(int elementsCount, int itemsPerPage = 5, string action = "Index") : base(elementsCount, itemsPerPage, action)
        {
        }
        public IndexReservationsViewModel() : base(0)
        {
        }
        public string UserId { get; set; }
        public ICollection<IndexReservationViewModel> Registartions { get; set; } = new List<IndexReservationViewModel>();

    }
}
