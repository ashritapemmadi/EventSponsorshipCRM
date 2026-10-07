using EventSponsorshipCRM.Data;
using EventSponsorshipCRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSponsorshipCRM.Controllers
{
    [Authorize]
    public class LeadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leads = _context.Leads.ToList();
            return View(leads);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lead lead)
        {
            if (!ModelState.IsValid)
                return View(lead);

            lead.CreatedDate = DateTime.Now;

            _context.Leads.Add(lead);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}