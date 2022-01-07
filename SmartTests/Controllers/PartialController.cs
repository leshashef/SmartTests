using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTests.Models;
using SmartTests.Models.Context;
using SmartTests.ViewModels;

namespace SmartTests.Controllers
{
    public class PartialController : Controller
    {
        AppDbContext context;
        public PartialController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FastRegister()
        {
            return PartialView(new FastRegisterModel() {Name="" });
        }

        [HttpPost]
        public async Task<ActionResult> FastRegister(FastRegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                    // добавляем пользователя в бд
                UserModel  user = new UserModel { Name = registerModel.Name};
                RoleModel userRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "first_registration");
                if (userRole != null)
                    user.Role = userRole;

                context.Users.Add(user);
                await context.SaveChangesAsync();

                await Authenticate(user);

            }
            return Redirect("~/Home");
        }

        private async Task Authenticate(UserModel user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim("Name", user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            
        }
    }
}
