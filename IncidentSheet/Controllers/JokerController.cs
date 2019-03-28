using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IncidentSheet.Models;
using IncidentSheet.ViewModels;
using IncidentSheet.Data;
using System.Linq;
using PagedList;


namespace IncidentSheet.Controllers
{
    
    public class JokerController : Controller
    {   
        private JokerDbContext context;

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

                return View("NewEntry");
            }
            addJokerViewModel = new AddJokerViewModel();
            return View("Add");


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

            return View("/");
        }

        public IActionResult Search(string searchBy, string search, int? page, string sort)
        {
            ViewBag.SortByUnit = string.IsNullOrEmpty(sort) ? "Unit desc" : "";
            ViewBag.SortByIncidentDate = sort == "IncidentDate" ? "IncidentDate desc" : "IncidentDate";
            ViewBag.SortByIncident = sort == "Incident" ? "Incident desc" : "Incident";

            var jokers = context.Jokers.AsQueryable();

            if (searchBy == "Unit")
            {
                jokers = jokers.Where(x => x.Unit.Equals(search) || search == null);       
            }
            if (searchBy == "IncidentDate")
            {
                jokers = jokers.Where(x => x.IncidentDate.Equals(search) || search == null);     
            }
            if (searchBy == "Incident")
            {
                jokers = jokers.Where(x => x.Unit.Equals(search) || search == null);     
            }
            switch(sort)
            {
                case "Unit desc":
                    jokers = jokers.OrderByDescending(x => x.Unit);
                    break;
                case "IncidentDate desc":
                    jokers = jokers.OrderByDescending(x => x.IncidentDate);
                    break;
                case "Incident desc":
                    jokers = jokers.OrderByDescending(x => x.Incident);
                    break;
                default:
                    jokers = jokers.OrderBy(x => x.Unit);
                    break;
            }

            return View(jokers.ToPagedList( page ?? 1, 3));
        }

        public ActionResult Details(int id)
        {
            Joker joker = context.Jokers.Single(jok => jok.ID == id);

            return View(joker);
        }
    }
    
}
/*
 public async Task<IActionResult> Edit(int? id)
 {
     if (id == null)
     {
         return NotFound();
     }

     var joker = await _context.Joker.FindAsync(id);
     if (joker == null)
     {
         return NotFound();
     }
     return View(joker);
 }

 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Edit(int id, [Bind("ID,IncidentDate,IncidentTime,Unit,Incident,Summary")]Joker joker )
 {
     if(id != joker.ID)
     {
         return NotFound();
     }

     if(ModelState.IsValid)
     {
         try
         {
             _context.Update(joker);
             await _context.SaveChangesAsync();
         }
         catch //(DbContextUpdateConcurencyException)
         {
             if (!JokerExists(joker.ID))
             {
                 return NotFound();
             }
             else
             {
                 throw;
             }
         }
         return RedirectToAction("Index");
     }
     return View(joker);
 }

} 
}*/

        
        
