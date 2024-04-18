using FlightManager.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.ViewModels.Flights
{
    public class IndexFlightsViewModel : PagingViewModel
    {
        public IndexFlightsViewModel(int elementsCount, int itemsPerPage = 5, string action = "Index") : base(elementsCount, itemsPerPage, action)
        {
        }
        public IndexFlightsViewModel() : base(0)
        {
        }
        public ICollection<IndexFlightViewModel> Flights { get; set; } = new List<IndexFlightViewModel>();
    }
}
