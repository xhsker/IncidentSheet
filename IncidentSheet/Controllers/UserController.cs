using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IncidentSheet.Models;
using IncidentSheet.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using IncidentSheet.Data;
using System.Linq;

namespace IncidnetLog.Controllers
{
    public class UserController : Controller
    {
        private readonly JokerDbContext context;

        public UserController(JokerDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            var model = new DropDownViewModel { UnitType = UnitType.District1 };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index (DropDownViewModel model)
        {
            return View(model);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);

        }
        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new IncidentSheet.Models.User
                {
                    UserName = addUserViewModel.UserName,
                    UserPassword = addUserViewModel.UserPassword
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return View("/User");
            }
            return View(addUserViewModel);
        }
    }
}