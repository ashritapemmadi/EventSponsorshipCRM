using System.Linq;
using EventSponsorshipCRM.Data;
using Microsoft.AspNetCore.Mvc;
using EventSponsorshipCRM.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EventSponsorshipCRM.Controllers
{
    [Authorize]
    public class SponsorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SponsorController(ApplicationDbContext context)
        {
            _context = context;
        }
    public IActionResult Index(){
    var sponsors = _context.Sponsors.ToList();
    return View(sponsors);
    }
    [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Sponsor sponsor)
{
    if (!ModelState.IsValid)
    {
        return View(sponsor);
    }

    sponsor.CreatedDate = DateTime.Now;

    _context.Sponsors.Add(sponsor);
_context.SaveChanges();

var audit = new AuditLog
{
    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
    Action = "Create",
    EntityName = "Sponsor",
    RecordId = sponsor.SponsorId,
    Details = "Sponsor created",
    CreatedDate = DateTime.Now
};

_context.AuditLogs.Add(audit);
_context.SaveChanges();

return RedirectToAction("Index");
}
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, Sponsor sponsor)
{
    if (id != sponsor.SponsorId)
    {
        return NotFound();
    }

    if (!ModelState.IsValid)
    {
        return View(sponsor);
    }

    _context.Sponsors.Update(sponsor);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Delete(int id)
{
    var sponsor = _context.Sponsors.Find(id);

    if (sponsor == null)
    {
        return NotFound();
    }

    _context.Sponsors.Remove(sponsor);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
public IActionResult Edit(int id)
{
    var sponsor = _context.Sponsors.Find(id);

    if (sponsor == null)
    {
        return NotFound();
    }

    return View(sponsor);
}
    public IActionResult Create()
{
    return View();
}
    }
}