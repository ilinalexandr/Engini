using Company.Application.Services.Interfaces;
using Company.Application.Services;
using Company.Infrastructure.Data;
using Company.Infrastructure.Repositories;
using Company.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<CompanyDbContext>(options =>
            options.UseMySql(
                defaultConnection,
                ServerVersion.AutoDetect(defaultConnection)));

        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}