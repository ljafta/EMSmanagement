using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMS.Models.DatabaseContext;
using Microsoft.Extensions.Logging;
using BCXZone_SharedLibrary;

using Microsoft.EntityFrameworkCore;

namespace EMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
     public class Startup
    {
        public PlatformStartup st { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            // Config conf = new Config();
            //  conf.ReadConfig();
            st = new PlatformStartup(configuration, environment, "ems", "EMS API", "BCX", "lumko.jafta@bcx.co.za");
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new Config().GetConfig();
            services.AddDbContext<EMSDBContext>(options =>
            {
                options.UseSqlServer(config["EMSDatabaseConnectionString"],
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.CommandTimeout(300);
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            });

            st.ConfigureServices(services);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            st.Configure(app, env);
        }
    }
}
