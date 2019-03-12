using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IncidentSheet.Models;
using IncidentSheet.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using IncidentSheet.Data;
using System.Linq;

namespace IncidentLog.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string searchBy, string searchInput)
        {
            if (searchBy == "Unit")
            {
                return View(/*db.Joker.Where(x => x.Unit.StartsWith(search) || search == null).ToList()*/);
            }
            if (searchBy == "IncidentDate")
            {
                return View(/*db.Joker.Where(x => x.IncidentDate == search || search == null).ToList()*/);
            }
            if (searchBy == "Incident")
            {
                return View(/*db.Joker.Where(x => x.Incident.StartsWith(search) || search == null).ToList()*/);
            }
            return View();
        }
    }
}