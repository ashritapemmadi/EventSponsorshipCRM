using EventSponsorshipCRM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSponsorshipCRM.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalSponsors = _context.Sponsors.Count();
            ViewBag.TotalLeads = _context.Leads.Count();
            ViewBag.TotalOpportunities = _context.Opportunities.Count();

            ViewBag.TotalValue = _context.Opportunities
                .Where(o => o.Status == "Active")
                .Sum(o => (decimal?)o.Amount) ?? 0;

            ViewBag.WeightedPipeline = _context.Opportunities
                .Where(o => o.Status == "Active")
                .Sum(o => (decimal?)(o.Amount * o.Probability / 100)) ?? 0;

            return View();
        }
    }
}