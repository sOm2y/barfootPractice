using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using barfootPractice.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using barfootPractice.Services;

namespace barfootPractice.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Listings")]
    public class ListingsController : Controller
    {
        private readonly BarfootContext _context;
        private readonly IMapper _mapper;
        private IUserService _userService;


        public ListingsController(BarfootContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Listings
        [HttpGet]
        public IActionResult GetListings()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (User.IsInRole(StaffRole.Sales))
            {
                var listings = _mapper.Map<List<ListingViewDto>>(_context.Listings);
                return Ok(listings);
            }
            if (User.IsInRole(StaffRole.SalesAdmin) || User.IsInRole(StaffRole.SalesDepartmentAdmin))
            {
                var listingsWithConfidential = _mapper.Map<List<ListingConfidentialViewDto>>(_context.Listings);
                return Ok(listingsWithConfidential);
            }
            return Ok();

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

            //TODO: create update dto for listing
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

            //TODO: create status entity and moving this check to helper class
            if(listing.Status == "withdrawn")
            {
                //TODO: change listing status to deleted instead of deleting real data from database
                _context.Listings.Remove(listing);
                await _context.SaveChangesAsync();

                return Ok(listing);
            }

            return BadRequest();

        }

        private bool ListingExists(int id)
        {
            return _context.Listings.Any(e => e.ListingId == id);
        }
    }
}