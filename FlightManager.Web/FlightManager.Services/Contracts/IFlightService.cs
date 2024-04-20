using FlightManager.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IFlightService
    {
        public Task<IndexFlightsViewModel> GetProjectsAsync(IndexFlightsViewModel model);
        public Task<int> GetFlightCountAsync();
        public Task<string> CreateFlightAsync(CreateFlightViewModel model);
        public Task<FlightDetailsViewModel> GetFlightDetails(string id);
        public Task<EditFlightViewModel?> GetFlightToEditAsync(string id);
        public Task<string> UpdateFlightAsync(EditFlightViewModel flight);
        public Task<int> DeleteFlightAsync(string id);
    }
}
