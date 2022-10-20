using Microsoft.EntityFrameworkCore;

namespace Model.Configurations;

public class TrainITDbContext : DbContext
{
    public TrainITDbContext(DbContextOptions<TrainITDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}