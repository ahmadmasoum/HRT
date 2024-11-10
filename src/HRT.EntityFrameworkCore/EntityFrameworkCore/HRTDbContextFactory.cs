using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HRT.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class HRTDbContextFactory : IDesignTimeDbContextFactory<HRTDbContext>
{
    public HRTDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        HRTEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<HRTDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new HRTDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HRT.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
