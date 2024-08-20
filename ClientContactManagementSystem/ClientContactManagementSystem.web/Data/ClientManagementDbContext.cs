using ClientContactManagementSystem.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientContactManagementSystem.web.Data
{

    public class ClientManagementDbContext : DbContext
    {
        public ClientManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Clients> tblClients { get; set; }

        public DbSet<Contact> tblContacts { get; set; }


    }
}
