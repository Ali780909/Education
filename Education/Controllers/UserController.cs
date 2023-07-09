using Education.Models;
using EducationModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Education
{
    public class UserController : Controller
    {
        UserManager<User> UserManager;
        SignInManager<User> SignInManager;
        RoleManager<IdentityRole> RoleManager;

        public UserController(UserManager<User> _UserManager,
            SignInManager<User> _SignInManager,
            RoleManager<IdentityRole> roleManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            RoleManager = roleManager;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.Roles = RoleManager.Roles
                .Select(i => new SelectListItem(i.Name, i.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            if (ModelState.IsValid == false)
                return View();
            else
            {
                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result
                      = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);
                    });
                    return View();
                }
                else
                {
                    await UserManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("SignIn", "User");
                }
            }
        }
        [HttpGet]
        public IActionResult SignIn(string ReturnUrl = null)
        {
            //ViewBag.UserName = c.Users.Select(i => new SelectListItem(i.UserName, i.UserName));
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.Title = "Sign In";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                User user = new User()
                {
                    UserName = model.UserName

                };
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded == false)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();

                }
                else
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return LocalRedirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
        }
        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            TempData["AlertMessage"] = "You Signed Out Successfully";

            return RedirectToAction("SignIn", "User");

        }

    }
}
