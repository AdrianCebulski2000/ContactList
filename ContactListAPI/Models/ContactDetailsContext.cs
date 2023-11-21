using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Models
{
    public class ContactDetailsContext : DbContext
    {
        public ContactDetailsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            
        //}
    }
   
}
