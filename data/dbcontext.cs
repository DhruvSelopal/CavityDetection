using Microsoft.EntityFrameworkCore;

public class DentalCheckUpContext : DbContext
{
    public DentalCheckUpContext(DbContextOptions<DentalCheckUpContext> options) : base(options) { }

    public DbSet<UserDbo> Users { get; set; }
    public DbSet<RecordDbo> Records { get; set; }
    public DbSet<ImageDbo> Images { get; set; }
}