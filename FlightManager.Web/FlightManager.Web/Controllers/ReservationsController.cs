using FlightManager.Data.Models;
using FlightManager.Data;
using FlightManager.ViewModels.Reservations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FlightManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Web.Controllers
{
    public class ReservationsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IReservationService reservationService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> userManager;

        public ReservationsController(ApplicationDbContext context, IReservationService reservationService, UserManager<User> userManager)
        {
            _context = context;
            this.reservationService = reservationService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(string id)
        {
            var model= await reservationService.GetReservationsToAddAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationViewModel model)
        {
            Flight flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == model.FlightId);
            model.Flight=flight;
            model.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                await reservationService.AddReservationAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
