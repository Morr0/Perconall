using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Perconall.Core.Factories;
using Perconall.Core.Repositories;
using Perconall.Core.Utilities.Configuration;
using Perconall.Core.Utilities.MappingProfiles;
using Perconall.Worker.BackgroundServices.EntriesService;

namespace Perconall.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<ConnectionStrings>(hostContext.Configuration.GetSection("ConnectionStrings"));

                    services.AddSingleton<EntryFactory>();
                    
                    services.AddDbContext<Database>((opts) =>
                    {
                        opts.UseNpgsql(hostContext.Configuration.GetSection("ConnectionStrings").GetSection("Postgresql").Value);
                    });

                    services.AddAutoMapper(MappingProfilesUtility.GetProfiles());
                    
                    services.AddHostedService<EntryService>();
                });
    }
}