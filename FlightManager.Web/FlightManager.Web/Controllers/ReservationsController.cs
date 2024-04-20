using FlightManager.Data.Models;
using FlightManager.Data;
using FlightManager.ViewModels.Reservations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FlightManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> Index(IndexReservationsViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = userId;
            model = await reservationService.GetMyRegistrationsAsync(model);
            return View(model);

        }
        public async Task<IActionResult> Create(string id)
        {
            ViewData["FlightId"] = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationViewModel model)
        {
            model.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await reservationService.AddReservationAsync(model);
            return RedirectToAction(nameof(Index));

        }
    }
}
