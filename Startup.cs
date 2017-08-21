using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using highload_travels.Models;

namespace highload_travels
{
    public class Startup
    {   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TravelsContext>(opt => opt.UseInMemoryDatabase());
            // Add framework services.
            services.AddMvc(options => {
                options.OutputFormatters.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            
            loggerFactory.AddConsole().AddDebug();
        }
    }
}
