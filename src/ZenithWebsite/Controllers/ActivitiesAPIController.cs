using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithWebsite.Data;
using ZenithWebsite.Models;

namespace ZenithWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/ActivitiesAPI")]
    public class ActivitiesAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivitiesAPI
        [HttpGet]
        public IEnumerable<Activity> GetActivity()
        {
            return _context.Activity;
        }

        // GET: api/ActivitiesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Activity activity = await _context.Activity.SingleOrDefaultAsync(m => m.ActivityId == id);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/ActivitiesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity([FromRoute] int id, [FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/ActivitiesAPI
        [HttpPost]
        public async Task<IActionResult> PostActivity([FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Activity.Add(activity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActivityExists(activity.ActivityId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivity", new { id = activity.ActivityId }, activity);
        }

        // DELETE: api/ActivitiesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Activity activity = await _context.Activity.SingleOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();

            return Ok(activity);
        }

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.ActivityId == id);
        }
    }
}