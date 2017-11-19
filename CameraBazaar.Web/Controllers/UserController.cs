namespace CameraBazaar.Web.Controllers
{
    using AutoMapper;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.BusinessModels;
    using CameraBazaar.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        public UserController(UserManager<User> userManager, IMapper mapper, IUserService userService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Edit()
        => View(this.userService.GetUserByUsername(User.Identity.Name));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var userData = await this.userManager.GetUserAsync(this.User);
            bool isValidPassword = await this.userManager.CheckPasswordAsync(userData, user.CurrentPassword);
            if (!isValidPassword)
            {
                ModelState.AddModelError("CurrentPassword", "Wrong password!");
                return View(user);
            }
            var hashedPassword = userManager.PasswordHasher.HashPassword(userData, user.Password);
            user.Password = hashedPassword;
            user.Id = this.userManager.GetUserId(User);
            this.userService.Update(user);
            return RedirectToAction("Index", "Home");
        }

    }
}