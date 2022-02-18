using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;
    public class ContactDbContext: DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options):base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(o => o.id);
        }
    }
