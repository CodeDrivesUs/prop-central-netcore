using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Data.Repositories;
using prop_central_netcore.Service;
using prop_central_netcore.Service.Interfaces;

namespace prop_central_netcore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //services
        builder.Services.AddSingleton<IAmenitiesService, AmenitiesService>();
        builder.Services.AddSingleton<IPopularPlacesService, PopularPlacesService>();
      //  builder.Services.AddSingleton<IAmenitiesService, AmenitiesService>();


        //repo
        builder.Services.AddSingleton<IAmenitiesRepository, AmenitiesRepository>();
        builder.Services.AddSingleton<IFlatImageRepository, FlatImageRepository>();
        builder.Services.AddSingleton<IPopularPlacesRepository, PopularPlacesRepository>();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllers();

        app.Run();
    }
}

