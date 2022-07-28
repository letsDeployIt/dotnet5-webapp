using System;

namespace dotnet5_webapp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Place { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsCreated { get; set; }
    }
}