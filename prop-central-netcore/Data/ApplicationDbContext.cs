using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace prop_central_netcore.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Initial Catalog=democodedrivesus_main;User ID=democodedrivesus_main;Password=Zweli@1;Encrypt=True;TrustServerCertificate=True;");
        }
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

