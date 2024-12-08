using IdentityApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using IdentityApp.Web.Models.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IdentityApp.Web.Controllers
{
    public class HomeController(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        SignInManager<AppUser> signInManager) : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append("name", "ahmet");

            var x = HttpContext.Session.Id;
            HttpContext.Session.SetString("x", "y");
            return View();
        }

        public async Task<IActionResult> Login()
        {
            var email = "ahmet16@outlook.com";
            var password = "Password12*";


            var hasUser = await userManager.FindByEmailAsync(email);


            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya ?ifre yanl??");
            }

            var passwordCheck = await userManager.CheckPasswordAsync(hasUser, password);

            if (!passwordCheck)
            {
                ModelState.AddModelError(string.Empty, "Email veya ?ifre yanl??");
            }


            await signInManager.SignInAsync(hasUser, new AuthenticationProperties() { IsPersistent = true });


            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> AddClaimToUser()
        {
            var user = await userManager.FindByNameAsync("ahmet16");

            await userManager.AddClaimAsync(user,
                new Claim("city", "istanbul"));


            userManager.UpdateSecurityStampAsync(user);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> AddRoleToUser()
        {
            var newRole = new AppRole()
            {
                Name = "Admin"
            };

            var response = await roleManager.CreateAsync(newRole);


            var user = await userManager.FindByNameAsync("ahmet16");


            await userManager.AddToRoleAsync(user, "Admin");


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UserCreate()
        {
            var appUse = new AppUser()
            {
                UserName = "ahmet16",
                Email = "ahmet16@outlook.com",
                City = "?stanbul"
            };


            var identityResult = await userManager.CreateAsync(appUse, "Password12*");


            if (!identityResult.Succeeded)
            {
            }

            return RedirectToAction("Index", "Home");
        }


        //[Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            var xkey = HttpContext.Session.GetString("x");


            var claims = User.Claims;

            var roles = claims.Where(x => x.Type == ClaimTypes.Role).ToList();


            var userName = User.Identity.Name;
            var uerId = claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return View();
        }


        [Authorize(policy: "ViolencePolicy")]
        public IActionResult ClaimAuthExample()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}