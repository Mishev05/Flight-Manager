using FlightManager.Data.Models;
using FlightManager.Data;
using FlightManager.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManager.ViewModels.Reservations;
using FlightManager.Common;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Services
{
    public class ReservationService : IReservationService
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private const int ItemsCount = 0;

        public ReservationService(UserManager<User> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<CreateReservationViewModel> GetReservationsToAddAsync(string id)
        {
            CreateReservationViewModel? result = null;

            Flight flight = await context.Flights.FirstOrDefaultAsync(x => x.Id == id);

            result = new CreateReservationViewModel()
            {
                FlightId = flight.Id
            };

            return result;

        }
        public async Task<int> AddReservationAsync(CreateReservationViewModel model)
        {
            Flight? f = await context.Flights.FirstOrDefaultAsync(x => x.Id == model.FlightId);
            Reservation reservation = null;
            if (f != null)
            {
                reservation = new Reservation()
                {
                    UserId = model.UserId,
                    FirstName = model.Firstname,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    UCN = model.UCN,
                    PhoneNumber = model.PhoneNumber,
                    Nationality = model.Nationality,
                    FlightId = model.FlightId,
                    TicketType = model.TicketType,
                    Flight = f
                };


                context.Reservations.Add(reservation);

            }
            return await context.SaveChangesAsync();

        }
        public async Task<IndexReservationsViewModel> GetMyRegistrationsAsync(IndexReservationsViewModel model)
        {
            User? user = await userManager.FindByIdAsync(model.UserId);
            IQueryable<Reservation> reservations = null;

            reservations = context.Reservations
                 .Where(x => x.UserId == model.UserId);
            model.ElementsCount = await GetMyReservationCountAsync(model.UserId);

            model.Registartions = await
                reservations
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new IndexReservationViewModel()
                {
                    Id = x.Id,
                    FullName = $"{x.User.FirstName} {x.User.LastName}",
                    FligthInfo = $"{x.Flight.DepartureTown} - {x.Flight.ArrivalTown}"
                })
                .ToListAsync();

            return model;
        }
        public async Task<int> GetMyReservationCountAsync(string userId)
        {
            return context.Reservations.Count(x => x.UserId == userId);
        }
    }
}
