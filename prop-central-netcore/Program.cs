using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using prop_central_netcore.Data;
using prop_central_netcore.Data.Interfaces;
using prop_central_netcore.Data.Repositories;
using prop_central_netcore.Service;
using prop_central_netcore.Service.Interfaces;
using prop_central_netcore.Shared.Configuration;

namespace prop_central_netcore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

       
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(AppSettings.DbConnectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        })
       .AddCookie()
       .AddGoogle(options =>
       {
           options.ClientId = "733975701128-kecq0uhevqueeq5u1ic6vtv1sl8e1f3n.apps.googleusercontent.com";
           options.ClientSecret = "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";
       });
//        builder.Services.AddAuthentication(options =>
//        {
//            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//        })
//.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
//.AddOpenIdConnect(
//    OpenIdConnectDefaults.AuthenticationScheme,
//    options =>
//    {
//        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
//        options.Authority = "https://propcentralsa.bsite.net";
//        options.ClientId = "interactive";
//        options.ClientSecret = "ClientSecret1";
//        options.RequireHttpsMetadata = false; 
//        options.ResponseType = "code";
//        options.SaveTokens = true;
//        options.GetClaimsFromUserInfoEndpoint = true;
//        options.Scope.Add("openid");
//        options.Scope.Add("profile");
//        options.TokenValidationParameters = new TokenValidationParameters()//Maps properties from jwtClaims
//        {
//            NameClaimType = JwtClaimTypes.Email,
//            RoleClaimType = JwtClaimTypes.Role
//        };
//    }
//);


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //services
        builder.Services.AddSingleton<IAmenitiesService, AmenitiesService>();
        builder.Services.AddSingleton<IPopularPlacesService, PopularPlacesService>();
        builder.Services.AddSingleton<IFlatImageService, FlatImageService>();
        builder.Services.AddSingleton<IFlatService, FlatService>();
        builder.Services.AddSingleton<IProfileService, ProfileService>();
        builder.Services.AddTransient<IRoomTypeService, RoomTypeService>();

        //repo
        builder.Services.AddSingleton<IAmenitiesRepository, AmenitiesRepository>();
        builder.Services.AddSingleton<IFlatImageRepository, FlatImageRepository>();
        builder.Services.AddSingleton<IPopularPlacesRepository, PopularPlacesRepository>();
        builder.Services.AddSingleton<IFlatImageRepository, FlatImageRepository>();
        builder.Services.AddSingleton<IFlatRepository, FlatRepository>();
        builder.Services.AddSingleton<IProfileRepository, ProfileRepository>();
        builder.Services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();



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
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
      //  app.MapControllers();

        app.Run();
    }
}

