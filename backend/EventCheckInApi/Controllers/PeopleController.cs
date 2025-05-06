using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EventCheckInApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetPeopleByEvent(int eventId)
        {
            var people = await _context.People
                .Where(p => p.CommunityId == eventId)
                .ToListAsync();

            return Ok(people);
        }

        [HttpGet("{eventId}/summary")]
        public async Task<IActionResult> GetEventSummary(int eventId)
        {
            var people = await _context.People
                .Where(p => p.CommunityId == eventId)
                .ToListAsync();

            var checkedInCount = people.Count(p => p.CheckInAt != null && p.CheckOutAt == null);
            var notCheckedInCount = people.Count(p => p.CheckInAt == null);
            
            var companyBreakdown = people
                .Where(p => p.CheckInAt != null && p.CheckOutAt == null)
                .GroupBy(p => p.Company ?? "Unknown")
                .Select(g => new {
                    name = g.Key,
                    count = g.Count()
                })
                .ToList();

            return Ok(new {
                attendeeCount = checkedInCount,
                notCheckedInCount,
                companyBreakdown
            });
        }

        [HttpPost("{personId}/checkin")]
        public async Task<IActionResult> CheckIn(int personId)
        {
            var person = await _context.People.FindAsync(personId);
            if (person == null) return NotFound();

            person.CheckInAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{personId}/checkout")]
        public async Task<IActionResult> CheckOut(int personId)
        {
            var person = await _context.People.FindAsync(personId);
            if (person == null) return NotFound();

            person.CheckOutAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
