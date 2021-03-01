using Microsoft.EntityFrameworkCore;
using Perconall.Core.Models;

namespace Perconall.Core.Repositories
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
            
        }
        
        public DbSet<Entry> EntryTable { get; set; }
    }
}