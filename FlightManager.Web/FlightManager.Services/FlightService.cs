using FlightManager.Data.Models;
using FlightManager.Data;
using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Flights;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightManager.Common;

namespace FlightManager.Services
{
    public class FlightService : IFlightService
    {
        private ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        public FlightService(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IndexFlightsViewModel> GetProjectsAsync(IndexFlightsViewModel model)
        {
            if (model == null)
            {
                model = new IndexFlightsViewModel();
            }
            model.ElementsCount = await GetFlightCountAsync();
            model.Flights = await context
            .Flights
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new IndexFlightViewModel()
                {
                    Id = x.Id,
                    DepartureFrom=x.DepartureTown,
                    ArrivalTo=x.ArrivalTown,
                    DepartureTime=$"{x.DepartureTime.ToLongDateString()} {x.DepartureTime.ToLongTimeString()}",
                    ArrivalTime= $"{x.ArrivalTime.ToLongDateString()} {x.ArrivalTime.ToLongTimeString()}",

                })
                .ToListAsync();

            return model;
        }

        public async Task<int> GetFlightCountAsync()
        {
            return await context.Flights.CountAsync();
        }
        public async Task<string> CreateFlightAsync(CreateFlightViewModel model)
        {
          

            Flight flight = new Flight()
            {
                DepartureTown=model.DepartureTown,
                ArrivalTown=model.ArrivalTown,
                DepartureTime=model.DepartureTime,
                ArrivalTime=model.ArrivalTime,
                PlaneType=model.PlaneType,
                UniquePlaneNumber=model.UniquePlaneNumber,
                PilotName=model.PilotName,
                PlaneRegularCapacity=model.RegularCapacity,
                PlaneBusinessCapacity=model.BusinessCapacity
            };
            context.Add(flight);
            await context.SaveChangesAsync();
            return flight.Id;
        }

        //public async Task<AddToTeamViewModel> GetUserToAddAsync(string id)
        //{
        //    AddToTeamViewModel? result = null;

        //    User? user = await GetUserByIdAsync(id);
        //    List<string> teamName = context.Teams.Select(x => x.Name).ToList();

        //    if (user != null)
        //    {
        //        result = new AddToTeamViewModel()
        //        {
        //            UserId = user.Id,
        //            TeamNames = teamName
        //        };
        //    }

        //    return result;

        //}
    }
}
