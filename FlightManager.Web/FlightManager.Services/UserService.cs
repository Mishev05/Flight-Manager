using FlightManager.Common;
using FlightManager.Data;
using FlightManager.Data.Models;
using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private const int ItemsCount = 0;

        public UserService(UserManager<User> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<string> CreateUserAsync(CreateUserViewModel model)
        {
            User user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                NationalId = model.NationalId,
                UCN = model.UCN,
                PhoneNumber = model.PhioneNumber
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (userManager.Users.Count() <= 1)
                {
                    IdentityRole roleAdmin = new IdentityRole() { Name = GlobalConstants.AdminRole };
                    IdentityRole roleUser = new IdentityRole() { Name = GlobalConstants.UserRole };

                    await roleManager.CreateAsync(roleAdmin);
                    await roleManager.CreateAsync(roleUser);
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdminRole);
                    user.MainRole = GlobalConstants.AdminRole;
                }
                else
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.UserRole);
                    user.MainRole = GlobalConstants.UserRole;
                }
                await userManager.UpdateAsync(user);
            }
            return user.Id;
        }

        public Task<bool> DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IndexUsersViewModel> GetUsersAsync(IndexUsersViewModel users)
        {
            if (users == null)
            {
                users = new IndexUsersViewModel(0);
            }
            users.ElementsCount = await GetUsersCountAsync();

            users.Users = await userManager
                .Users
                .Skip((users.Page - 1) * users.ItemsPerPage)
                .Take(users.ItemsPerPage)
                .Select(x => new IndexUserViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Role= x.MainRole
                })
                .ToListAsync();

            return users;
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await userManager.Users.CountAsync();
        }
    }

}
