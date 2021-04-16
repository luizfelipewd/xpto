using Microsoft.EntityFrameworkCore;
using XPTO.Models;

namespace XPTO.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<OS> OS { get; set; }
        public DbSet<User> Users { get; set; }
    }
}