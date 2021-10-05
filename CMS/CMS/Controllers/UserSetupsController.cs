using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Models;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSetupsController : ControllerBase
    {
        private readonly CMSContext _context;

        public UserSetupsController(CMSContext context)
        {
            _context = context;
        }

        // GET: api/UserSetups
        [HttpGet]
        //Get all the list of users
        public async Task<ActionResult<IEnumerable<UserSetup>>> GetUserSetup()
        {
            return await _context.UserSetup.ToListAsync();
        }

        // GET: api/UserSetups/5
        [HttpGet("{Username}")]
        //Get a user by id
        public async Task<ActionResult<UserSetup>> GetUserSetup(string Username)
        {
            var userSetup = await _context.UserSetup.FindAsync(Username);

            if (userSetup == null)
            {
                return NotFound();
            }

            return userSetup;
        }

        // PUT: api/UserSetups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Username}")]
        //Edit the user details by id
        public async Task<IActionResult> PutUserSetup(string Username, UserSetup userSetup)
        {
            if (Username == userSetup.Password)
            {
                return BadRequest();
            }

            _context.Entry(userSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSetupExists(Username))
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

        // POST: api/UserSetups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //Add a user
        public async Task<ActionResult<UserSetup>> PostUserSetup(UserSetup userSetup)
        {
            _context.UserSetup.Add(userSetup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserSetupExists(userSetup.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserSetup", new { Username = userSetup.Username }, userSetup);
        }

        // DELETE: api/UserSetups/5
        [HttpDelete("{Username}")]
        //Delete a user by id
        public async Task<IActionResult> DeleteUserSetup(string Username)
        {
            var userSetup = await _context.UserSetup.FindAsync(Username);
            if (userSetup == null)
            {
                return NotFound();
            }

            _context.UserSetup.Remove(userSetup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSetupExists(string Username)
        {
            return _context.UserSetup.Any(e => e.Password == Username);
        }
    }
}
