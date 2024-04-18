using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index(IndexUsersViewModel? model)
        {

            model = await service.GetUsersAsync(model);

            return View(model);
        }
    }
}
