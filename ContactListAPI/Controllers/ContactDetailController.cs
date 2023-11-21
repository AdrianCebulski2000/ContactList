using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactListAPI.Models;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
        private readonly ContactDetailsContext _context;

        public ContactDetailController(ContactDetailsContext context)
        {
            _context = context;
        }

        // GET: api/ContactDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDetail>>> GetContactDetails()
        {
          if (_context.ContactDetails == null)
          {
              return NotFound();
          }
            return await _context.ContactDetails.ToListAsync();
        }

        // GET: api/ContactDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetail>> GetContactDetail(int id)
        {
          if (_context.ContactDetails == null)
          {
              return NotFound();
          }
            var contactDetail = await _context.ContactDetails.FindAsync(id);

            if (contactDetail == null)
            {
                return NotFound();
            }

            return contactDetail;
        }

        // PUT: api/ContactDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetail(int id, ContactDetail contactDetail)
        {
            if (id != contactDetail.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contactDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.ContactDetails.ToListAsync());
        }

        // POST: api/ContactDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactDetail>> PostContactDetail(ContactDetail contactDetail)
        {
          if (_context.ContactDetails == null)
          {
              return Problem("Entity set 'ContactDetailsContext.ContactDetails'  is null.");
          }
            _context.ContactDetails.Add(contactDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.ContactDetails.ToListAsync());
        }

        // DELETE: api/ContactDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactDetail(int id)
        {
            if (_context.ContactDetails == null)
            {
                return NotFound();
            }
            var contactDetail = await _context.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            _context.ContactDetails.Remove(contactDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.ContactDetails.ToListAsync());
        }

        private bool ContactDetailExists(int id)
        {
            return (_context.ContactDetails?.Any(e => e.ContactId == id)).GetValueOrDefault();
        }
    }
}
