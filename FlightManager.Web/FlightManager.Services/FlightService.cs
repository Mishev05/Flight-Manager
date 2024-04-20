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

        public async Task<FlightDetailsViewModel> GetFlightDetails(string id)
        {
            Flight f = context.Flights.Where(y => y.Id == id).FirstOrDefault();
            if (f == null)
            {
                return null;
            }
            FlightDetailsViewModel model = new FlightDetailsViewModel()
            {
                Id=f.Id,
                DepartureTown=f.DepartureTown,
                ArrivalTown=f.ArrivalTown,
                DepartureTime= $"{f.DepartureTime.ToLongDateString()} {f.DepartureTime.ToLongTimeString()}",
                ArrivalTime= $"{f.ArrivalTime.ToLongDateString()} {f.ArrivalTime.ToLongTimeString()}",
                PlaneType = f.PlaneType,
                UniquePlaneNumber=f.UniquePlaneNumber,
                PilotName=f.PilotName,
                RegularCapacity=f.PlaneRegularCapacity,
                BusinessCapacity=f.PlaneBusinessCapacity
            };
            return model;
        }

        public async Task<EditFlightViewModel?> GetFlightToEditAsync(string id)
        {
            EditFlightViewModel? result = null;

            Flight? flight = await context.Flights.FirstOrDefaultAsync(x => x.Id == id);

            if (flight != null)
            {
                result = new EditFlightViewModel()
                {
                    Id = flight.Id,
                    DepartureTime=flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,
                    ArrivalTown= flight.ArrivalTown,
                    PilotName=flight.PilotName
                };
            }

            return result;
        }

        public async Task<string> UpdateFlightAsync(EditFlightViewModel flight)
        {
            Flight? oldFlight = await context.Flights.FirstOrDefaultAsync(x => x.Id == flight.Id);

            if (oldFlight != null)
            {
                oldFlight.DepartureTime = flight.DepartureTime;
                oldFlight.ArrivalTime = flight.ArrivalTime;
                oldFlight.ArrivalTown=flight.ArrivalTown;
                oldFlight.PilotName= flight.PilotName;
            }
            context.Update(oldFlight);
            await context.SaveChangesAsync();
            return flight.Id;
        }

        public async Task<int> DeleteFlightAsync(string id)
        {
            Flight? flight = await context.Flights.FirstOrDefaultAsync(x => x.Id == id);
            if (flight != null)
            {
                context.Flights.Remove(flight);
            }
            return await context.SaveChangesAsync();
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
