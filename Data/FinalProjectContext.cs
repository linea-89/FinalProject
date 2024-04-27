using Microsoft.EntityFrameworkCore;
using FinalProject.Data.Models;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options) { }


        public DbSet<Move> Moves { get; set; }
    
    }
}
