using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IncidentSheet.Models;
using IncidentSheet.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using IncidentSheet.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace IncidnetLog.Controllers
{
    public class UserController : Controller
    {
        private JokerDbContext context;

        public UserController(JokerDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<User> users = context.Users.ToList();

            return View(users);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddUserViewModel model)
        {
            List<User> users = context.Users.ToList();

            var userExists = users.Any(x => x.UserName == model.UserName);
            if (ModelState.IsValid)
            {
                return RedirectToAction("/User/Index");
            }
            else
            {
                User newUser = new User
                {
                    UserName = model.UserName,
                    UserPassword = model.UserPassword,

                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return RedirectToAction("Index", "Joker");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AddUserViewModel model)
        {
            List<User> users = context.Users.ToList();

            var userExists = users.Any(x => x.UserName == model.UserName);
            if (ModelState.IsValid)
            {
                return View(userExists);
            }
            else
            {
                return Redirect("/Joker");
            }
        }
    }
}