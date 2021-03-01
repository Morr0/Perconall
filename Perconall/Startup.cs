using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Perconall.Core.Repositories;
using Perconall.Services.EntryService;

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
            services.AddControllers();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<EntryFactory>();

            services.AddTransient<IEntryService, EntryService>();
            
            services.AddDbContext<Database>((opts) =>
            {
                opts.UseNpgsql(
                    _configuration.GetSection("ConnectionStrings").GetSection("Postgresql").Value,
                    x => x.MigrationsAssembly("Perconall.PublicApi"));
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}