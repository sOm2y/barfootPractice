using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using barfootPractice.Models;
using Microsoft.AspNetCore.Authorization;

namespace barfootPractice.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Listings")]
    public class ListingsController : Controller
    {
        private readonly BarfootContext _context;

        public ListingsController(BarfootContext context)
        {
            _context = context;
        }

        // GET: api/Listings
        [HttpGet]
        public IEnumerable<Listing> GetListings()
        {
            return _context.Listings;
        }

        // GET: api/Listings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listing = await _context.Listings.SingleOrDefaultAsync(m => m.ListingId == id);

            if (listing == null)
            {
                return NotFound();
            }

            return Ok(listing);
        }

        // PUT: api/Listings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListing([FromRoute] int id, [FromBody] Listing listing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listing.ListingId)
            {
                return BadRequest();
            }

            _context.Entry(listing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(id))
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

        // POST: api/Listings
        [Authorize(Roles = StaffRole.Sales + "," + StaffRole.SalesDepartmentAdmin)]
        [HttpPost]
        public async Task<IActionResult> PostListing([FromBody] Listing listing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListing", new { id = listing.ListingId }, listing);
        }

        // DELETE: api/Listings/5
        [Authorize(Roles = StaffRole.SalesDepartmentAdmin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listing = await _context.Listings.SingleOrDefaultAsync(m => m.ListingId == id);
            if (listing == null)
            {
                return NotFound();
            }

            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();

            return Ok(listing);
        }

        private bool ListingExists(int id)
        {
            return _context.Listings.Any(e => e.ListingId == id);
        }
    }
}