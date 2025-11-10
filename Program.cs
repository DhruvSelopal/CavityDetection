using Microsoft.EntityFrameworkCore;

class Progrm
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<DentalCheckUpContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlServer"]));

        builder.Services.AddControllers();

        WebApplication app = builder.Build();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}