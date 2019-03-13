using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IncidentSheet.Models;
using IncidentSheet.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using IncidentSheet.Data;
using System.Linq;

namespace IncidentSheet.Controllers
{
    public class JokerController : Controller
    {
        private readonly JokerDbContext context;

        public JokerController(JokerDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Joker> jokers = context.Jokers.ToList();

            return View(jokers);
        }


        public IActionResult Add()
        {
            AddJokerViewModel addJokerViewModel = new AddJokerViewModel();
            return View(addJokerViewModel);

        }
        [HttpPost]
        public IActionResult Add(AddJokerViewModel addJokerViewModel)
        {
            if (ModelState.IsValid)
            {
                Joker newJoker = new Joker
                {
                    IncidentDate = addJokerViewModel.IncidentDate,
                    IncidentTime = addJokerViewModel.IncidentTime,
                    Unit = addJokerViewModel.Unit,
                    Incident = addJokerViewModel.Incident,
                    Summary = addJokerViewModel.Summary
                };

                context.Jokers.Add(newJoker);
                context.SaveChanges();

                return View("/NewEntry");
            }
            return View(addJokerViewModel);
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Joker Entry";
            ViewBag.jokers = context.Jokers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Remove(int[] jokerIds)
        {
            foreach (int jokerId in jokerIds)
            {
                Joker theJoker = context.Jokers.Single(c => c.ID == jokerId);
                context.Jokers.Remove(theJoker);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Search(string searchBy, string search)
        {
            List<Joker> jokers = context.Jokers.ToList();

            if (searchBy == "Unit")
            {
                return View(jokers.Where(x => x.Unit.Equals(search) || search == null).ToList());
            }
            if (searchBy == "IncidentDate")
            {
                return View(jokers.Where(x => x.IncidentDate.Equals(search) || search == null).ToList());
            }
            if (searchBy == "Incident")
            {
                return View(jokers.Where(x => x.Incident.StartsWith(search) || search == null).ToList());
            }
        }
    } 
}
       