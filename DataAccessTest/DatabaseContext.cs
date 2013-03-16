using System.Data.Entity;
using DataAccessTest.Model;

namespace DataAccessTest
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}