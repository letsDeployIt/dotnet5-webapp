using dotnet5_webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet5_webapp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
        public DbSet<Contact> Contacts { get; set; }
    }
}