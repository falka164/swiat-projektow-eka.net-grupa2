using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meetapp.Core;
using Meetapp.Core.Entities;
using Meetapp.Core.Responses;
using Meetapp.Services.Interfaces;

namespace Meetapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventService _eventService;

        public EventsController(ApplicationDbContext context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            EventResponse eventResponse = (EventResponse)await _eventService.GetEvent(id);


            if (!eventResponse.Succes)
            {
                return BadRequest(eventResponse);
            }
            else return Ok(eventResponse.eventPayload);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("PostEvent")]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostEvent(string startDate, string endDate, string saleExpDate, string cost, string title, string location, string category, string reqConfirm)
        {
            Response response = await _eventService.CreateEvent(
                DateTime.Parse(startDate),
                DateTime.Parse(endDate),
                DateTime.Parse(saleExpDate),
                int.Parse(cost),
                title,
                location,
                category,
                bool.Parse(reqConfirm));
            if (!response.Succes)
            {
                return BadRequest(response);
            }
            else return Ok(response);

        }

        // DELETE: api/Events/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            Response eventResponse = await _eventService.DeleteEvent(id);

            if (!eventResponse.Succes)
            {
                return BadRequest(eventResponse);
            }
            else return Ok(eventResponse);
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
