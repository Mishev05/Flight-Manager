using FlightManager.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IReservationService
    {
        public Task<int> AddReservationAsync(CreateReservationViewModel model);
        public Task<CreateReservationViewModel> GetReservationsToAddAsync(string id);
        public Task<IndexReservationsViewModel> GetMyRegistrationsAsync(IndexReservationsViewModel model);
        public Task<int> GetMyReservationCountAsync(string userId);
    }
}
