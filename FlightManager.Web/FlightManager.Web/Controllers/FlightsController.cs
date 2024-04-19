using FlightManager.Common;
using FlightManager.Data;
using FlightManager.Data.Models;
using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Flights;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IFlightService flightService;
        private readonly UserManager<User> userManager;

        public FlightsController(ApplicationDbContext context, IFlightService flightService, UserManager<User> userManager)
        {
            context = context;
            this.flightService = flightService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(IndexFlightsViewModel model)
        {
            model = await flightService.GetProjectsAsync(model);
            return View(model);
        }

        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Set
        [HttpPost]
        public async Task<IActionResult> Create(CreateFlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                await flightService.CreateFlightAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
}
