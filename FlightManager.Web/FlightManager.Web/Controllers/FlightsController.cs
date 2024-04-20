using FlightManager.Common;
using FlightManager.Data;
using FlightManager.Data.Models;
using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Flights;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Index(IndexFlightsViewModel model)
        {
            model = await flightService.GetProjectsAsync(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
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
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await flightService.GetFlightDetails(id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await flightService.GetFlightToEditAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditFlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                await flightService.UpdateFlightAsync(model);
                return this.RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await flightService.DeleteFlightAsync(id);


            return RedirectToAction(nameof(Index));
        }

    }
}
