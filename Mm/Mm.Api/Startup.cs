using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mm.Api.Mapping;
using Mm.Api.Models;
using Mm.Api.Repositories;

namespace Mm.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<mmContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddMvc();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(c => new UrlHelper(c.GetService<IActionContextAccessor>().ActionContext));

            // dependencies
            services.AddSingleton<IMapperConfiguration, MapperConfiguration>();
            services.AddSingleton<IMapperService, MapperService>();
            services.AddScoped<IObjPropertiesRepository, ObjPropertiesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
