using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet5_webapp.Data;
using dotnet5_webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet5_webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts.Where(c=> c.IsDeleted == false).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = _context.Contacts.FindAsync(id).Result;
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            var dbContact = await _context.Contacts.FindAsync(id);
            if (dbContact == null)
            {
                return NotFound();  
            }

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.NickName = contact.NickName;
            dbContact.Place = contact.Place;

            await _context.SaveChangesAsync();
            return Ok(dbContact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(_context.Contacts);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Ok(_context.Contacts);
        }

        private bool ContactExists(int id)  
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}