using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCheckInApi.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint que retorna todos os eventos
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Communities.ToListAsync();
            return Ok(events);
        }

        // Novo endpoint para obter o resumo do evento
        [HttpGet("{eventId}/summary")]
        public async Task<IActionResult> GetEventSummary(int eventId)
        {
            var eventSummary = await _context.Communities
                .Where(e => e.Id == eventId)
                .Select(e => new
                {
                    AttendeeCount = e.People.Count(),
                    NotCheckedInCount = e.People.Count(p => p.CheckInAt == null),
                    CompanyBreakdown = e.People
                        .GroupBy(p => p.Company)
                        .Select(g => new
                        {
                            Company = g.Key,
                            Count = g.Count()
                        })
                })
                .FirstOrDefaultAsync();

            if (eventSummary == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(eventSummary);
        }
    }
}
