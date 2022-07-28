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
        public IEnumerable<Contact> Get()
        {
            return _contacts;
        }
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}