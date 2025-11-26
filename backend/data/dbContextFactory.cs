using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DentalCheckUpContextFactory : IDesignTimeDbContextFactory<DentalCheckUpContext>
{
    public DentalCheckUpContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DentalCheckUpContext>();

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer("Server=DESKTOP-8HPE4AQ;Database=DentalCheckUp;Trusted_Connection=True;TrustServerCertificate=True;"); // replace with real connection string

        return new DentalCheckUpContext(optionsBuilder.Options);
    }
}
