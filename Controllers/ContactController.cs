using System.Collections.Generic;
using System.Linq;
using dotnet5_webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet5_webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private List<Contact> _contacts = new List<Contact>()
        {
            new Contact {Id = 1, FirstName = "Dal", LastName = "Ci", NickName = "Cut", Place = "NY"},
            new Contact {Id = 2, FirstName = "Dal0", LastName = "Ci0", NickName = "Cut0", Place = "NY0"},
        };
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return _contacts;
        }
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact has not been found." });
            }
            return Ok(contact);
        }
        
        [HttpPost]
        public ActionResult<IEnumerable<Contact>> Post(Contact contact)
        {
            _contacts.Add(contact);
            return _contacts;
        }
        
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Contact>> Put(int id, Contact updatedContact)
        {
            Contact contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact has not been found." });
            }

            contact.NickName = updatedContact.NickName;
            contact.IsDeleted = updatedContact.IsDeleted;
            return Ok(_contacts);
        }
    }
}