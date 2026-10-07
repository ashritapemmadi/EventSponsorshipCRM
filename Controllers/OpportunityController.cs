using EventSponsorshipCRM.Data;
using EventSponsorshipCRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSponsorshipCRM.Controllers
{
    [Authorize]
    public class OpportunityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var opportunities = _context.Opportunities.ToList();
            return View(opportunities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Opportunity opportunity)
        {
            if (opportunity.Status == "Active" &&
                opportunity.ExpectedCloseDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "ExpectedCloseDate",
                    "Expected close date cannot be in the past.");
            }

            if (!ModelState.IsValid)
            {
                return View(opportunity);
            }

            opportunity.CreatedDate = DateTime.Now;

            _context.Opportunities.Add(opportunity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}