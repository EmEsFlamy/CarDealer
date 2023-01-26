using Microsoft.EntityFrameworkCore;
using ProjektSR.Database;
using ProjektSR.Interfaces;
using ProjektSR.Repositories;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICarRepository, CarRepository>();

        builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlite(@"DataSource=appliaction.db;"));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        Configure(app);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void Configure(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbServ = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        if (dbServ is not null)
            dbServ.Database.Migrate();
    }
}