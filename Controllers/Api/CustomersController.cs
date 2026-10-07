using EventSponsorshipCRM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSponsorshipCRM.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _context.Sponsors
                .Select(s => new
                {
                    s.SponsorId,
                    s.SponsorCode,
                    s.SponsorName,
                    s.ContactPerson,
                    s.Email,
                    s.Phone,
                    s.Status
                })
                .ToList();

            return Ok(customers);
        }
    }
}