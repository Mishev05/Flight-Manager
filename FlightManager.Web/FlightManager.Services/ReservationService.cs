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

            Flight flight= await context.Flights.FirstOrDefaultAsync(x=>x.Id==id);

            result = new CreateReservationViewModel()
            {
                FlightId=flight.Id
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
                    FirstName=model.Firstname,
                    MiddleName=model.MiddleName,
                    LastName=model.LastName,
                    UCN=model.UCN,
                    PhoneNumber=model.PhoneNumber,
                    Nationality=model.Nationality,
                    FlightId=model.FlightId,
                    TicketType=model.TicketType,
                    Flight=f
                };


                context.Reservations.Add(reservation);

            }
            return await context.SaveChangesAsync();

        }

    }
}
