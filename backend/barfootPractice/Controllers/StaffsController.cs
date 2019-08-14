using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using barfootPractice.Models;
using Microsoft.AspNetCore.Authorization;
using barfootPractice.Services;

namespace barfootPractice.Controllers
{
    [Authorize(Roles = StaffRole.SalesDepartmentAdmin)]
    [Produces("application/json")]
    [Route("api/Staffs")]
    public class StaffsController : Controller
    {
        private readonly BarfootContext _context;
        private readonly IUserService _userService;

        public StaffsController(BarfootContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/Staffs/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]Staff userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // GET: api/Staffs
        [HttpGet]
        public IEnumerable<Staff> GetStaffs()
        {
            return _context.Staffs;
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staff = await _context.Staffs.SingleOrDefaultAsync(m => m.StaffId == id);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff([FromRoute] int id, [FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        [HttpPost]
        public async Task<IActionResult> PostStaff([FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staff = await _context.Staffs.SingleOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            //TODO: change listing status to deleted instead of deleting real data from database
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return Ok(staff);
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}