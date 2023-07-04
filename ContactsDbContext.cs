using ContactOrganiser.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactOrganiser
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }


        public DbSet<Contact> Contacts { get; set; }

    }
}
