using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Perconall.Core.Factories;
using Perconall.Core.Repositories;
using Perconall.Core.Utilities.Configuration;
using Perconall.Core.Utilities.MappingProfiles;
using Perconall.Services.EntryService;
using Perconall.Services.MessageQueueingService;

namespace Perconall
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConnectionStrings>(_configuration.GetSection("ConnectionStrings"));
            
            services.AddControllers();
            services.AddAutoMapper(MappingProfilesUtility.GetProfiles());

            services.AddSingleton<EntryFactory>();

            services.AddTransient<IEntryService, EntryService>();

            var serviceProvider = services.BuildServiceProvider();
            var connectionStrings = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>();
            services.AddDbContext<Database>((opts) =>
            {
                opts.UseNpgsql(connectionStrings.Value.Postgresql,
                    x => x.MigrationsAssembly("Perconall.PublicApi"));
            });
            serviceProvider.Dispose();

            services.AddSingleton<IMessageQueueService, MessageQueueService>();

            services.AddCors(x =>
            {
                x.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}