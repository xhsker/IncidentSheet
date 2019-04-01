using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IncidentSheet.Data;
using IncidentSheet.Models;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using X.PagedList;

namespace IncidentSheet.Controllers
{
    public class JokersController : Controller
    {
        private readonly JokerDbContext _context;

        public JokersController(JokerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            {
                ViewBag.SortUnit = string.IsNullOrEmpty(sortBy) ? "Unit_desc" : " ";
                ViewBag.SortDate = sortBy == "IncidentDate" ? "IncidentDate_desc" : "IncidentDate";
                ViewBag.SortIncident = sortBy == "Incident" ? "Incident_desc" : "Incident";

                var joker = _context.Jokers.AsQueryable();

                if (searchBy == "Unit")
                {
                    joker = joker.Where(x => x.Unit.ToString() == search || search == null);
                }
                if (searchBy == "IncidentDate")
                {
                    joker = joker.Where(x => x.IncidentDate.ToString("MM/dd/yyyy") == search || search == null);
                }
                if (searchBy == "Incident")
                {
                    joker = joker.Where(x => x.Incident.StartsWith(search) || search == null);
                }
                else
                {
                    joker = joker.Where(x => x.Incident.StartsWith(search) || search == null);
                }
                switch (sortBy)
                {
                    case "Unit_desc":
                        joker = joker.OrderByDescending(x => x.Unit);
                        break;
                    case "IncidentDate_desc":
                        joker = joker.OrderByDescending(x => x.IncidentDate);
                        break;
                    case "Incident_desc":
                        joker = joker.OrderByDescending(x => x.Incident);
                        break;
                    default:
                        joker = joker.OrderByDescending(x => x.Unit);
                        break;
                }

                return View(joker.ToPagedList(page ?? 1, 5));

            }
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joker = await _context.Jokers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (joker == null)
            {
                return NotFound();
            }

            return View(joker);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncidentDate,IncidentTime,Unit,Incident,Summary,ID")] Joker joker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joker);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joker = await _context.Jokers.FindAsync(id);
            if (joker == null)
            {
                return NotFound();
            }
            return View(joker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncidentDate,IncidentTime,Unit,Incident,Summary,ID")] Joker joker)
        {
            if (id != joker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
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
                return RedirectToAction(nameof(Index));
            }
            return View(joker);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joker = await _context.Jokers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (joker == null)
            {
                return NotFound();
            }

            return View(joker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joker = await _context.Jokers.FindAsync(id);
            _context.Jokers.Remove(joker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JokerExists(int id)
        {
            return _context.Jokers.Any(e => e.ID == id);
        }

        public IActionResult Search(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortUnit = string.IsNullOrEmpty(sortBy) ? "Unit desc" : "";
            ViewBag.SortDate = sortBy == "IncidentDate" ? "IncidentDate desc" : "IncidentDate";
            ViewBag.SortIncident = sortBy == "Incident" ? "Incident desc" : "Incident";

            var joker = _context.Jokers.AsQueryable();

            if (searchBy == "Unit")
            {
                joker = joker.Where(x => x.Unit.ToString() == search || search == null);
            }
            if (searchBy == "IncidentDate")
            {
                joker = joker.Where(x => x.IncidentDate.ToString("MM/dd/yyyy") == search || search == null);
            }
            if (searchBy == "Incident")
            {
                joker = joker.Where(x => x.Incident.StartsWith(search) || search == null);
            }
            else
            {
                joker = joker.Where(x => x.Incident.StartsWith(search) || search == null);
            }
            switch (sortBy)
            {
                case "Unit desc":
                    joker = joker.OrderByDescending(x => x.Unit);
                    break;
                case "IncidentDate desc":
                    joker = joker.OrderByDescending(x => x.IncidentDate);
                    break;
                case "Incident desc":
                    joker = joker.OrderByDescending(x => x.Incident);
                    break;
                default:
                    joker = joker.OrderByDescending(x => x.Unit);
                    break;
            }

            return View(joker.ToPagedList(page ?? 1, 20));

        }

        public IActionResult List()
        {
            List<Joker> listJoker = _context.Jokers.ToList();

            return View(listJoker);
        }
    }
}
