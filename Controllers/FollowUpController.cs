using EventSponsorshipCRM.Data;
using EventSponsorshipCRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSponsorshipCRM.Controllers
{
    [Authorize]
    public class FollowUpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var followUps = _context.FollowUps
                .OrderBy(f => f.FollowUpDate)
                .ToList();

            return View(followUps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FollowUp followUp)
        {
            if (followUp.FollowUpDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "FollowUpDate",
                    "Follow-up date cannot be before today.");
            }

            if (!ModelState.IsValid)
            {
                return View(followUp);
            }

            _context.FollowUps.Add(followUp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}