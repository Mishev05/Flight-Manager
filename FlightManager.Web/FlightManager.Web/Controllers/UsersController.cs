//using FlightManager.Common;
//using FlightManager.Services.Contracts;
//using FlightManager.ViewModels.Users;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace FlightManager.Web.Controllers
//{
//    public class UsersController : Controller
//    {
//        private readonly IUserService service;

//        public UsersController(IUserService service)
//        {
//            this.service = service;
//        }
//        public async Task<IActionResult> Index(IndexUsersViewModel? model)
//        {

//            model = await service.GetUsersAsync(model);

//            return View(model);
//        }
//        [HttpGet]
//        public async Task<IActionResult> Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Create(CreateUserViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                await service.CreateUserAsync(model);
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Seed()
//        {
//            const string Password = "123456";
//            for (int i = 0; i < 20; i++)
//            {
//                string result = await service.CreateUserAsync(

//                      new CreateUserViewModel()
//                      {
//                          FirstName = $"Name {i}",
//                          LastName = $"LastName {i}",
//                          Password = Password,
//                          ConfirmPassword = Password,
//                          Email = $"user{i}@app.bg",
//                          NationalId = "0000000000",
//                          Address=$"Adress {i}",
//                          UCN="0000000000",
//                          PhioneNumber="0000000000",
//                          Role = GlobalConstants.UserRole
//                      }
//                      ) ;
//            }
//            return RedirectToAction(nameof(Index));
//        }


//        [HttpGet]
//        public async Task<IActionResult> Details(string id)
//        {
//            var userViewModel = await service.GetUserDetailsAsync(id);
//            if (userViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(userViewModel);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit(string id)
//        {
//            var model = await service.GetUserToEditAsync(id);
//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(EditUserViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                await service.UpdateUserAsync(model);
//                return this.RedirectToAction(nameof(Index));
//            }
//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Delete(string id)
//        {
//            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            if (id != userId)
//            {
//                await service.DeleteUserAsync(id);
//            }

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
