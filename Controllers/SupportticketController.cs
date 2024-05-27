using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soporte_back_dotnet.Model;
using System;
using System.Net.Sockets;

namespace soporte_back_dotnet.Controllers
{

    [ApiController]
    [Route("api/support/tickets")]
    public class SupportticketController : Controller
    {
        
        private readonly supportDbContext _context;

        public SupportticketController(supportDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supportticket>>> GetAllTicketsAsync()
        {
            return await _context.Supporttickets.ToListAsync();
        }

        // GET: api/support/tickets/{id}
        [HttpGet("{id}")]
        public ActionResult<Supportticket> GetTicketById(int id)
        {
            var ticket = _context.Supporttickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        // POST: api/support/tickets/createTicket/
        //Y eso tambien
        [HttpPost("createTicket")]
        public ActionResult<Supportticket> CreateTicket([FromBody] Supportticket ticket)
        {
            _context.Supporttickets.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
        }

        // PUT: api/support/tickets/{ticketId}/update-answer
        //Comentar esto
        [HttpPut("{ticketId}/update-answer")]
        public async Task<ActionResult<Supportticket>> UpdateAnswerAsync([FromRoute] int ticketId, [FromBody] Supportticket request)
        {
            if (ticketId != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Supporttickets.Any(e => e.Id == ticketId))
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

        // PUT: api/support/tickets/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Supportticket>> UpdateTicketAsync([FromRoute] int id, [FromBody] Supportticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Supporttickets.Any(e => e.Id == id))
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

        // DELETE: api/support/tickets/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketAsync([FromRoute] int id)
        {
            var ticket = await _context.Supporttickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Supporttickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
