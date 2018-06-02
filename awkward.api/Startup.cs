using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awkward.api.Data;
using awkward.api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace awkward.api
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
            services.AddMvc();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=YourDbFileName.sqlite"));
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Info { Title = "Enitity Comparitor", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Entity Comparitor"));

                app.UseDeveloperExceptionPage();

                ApplicationContext.Seed(app.ApplicationServices);
            }

            app.UseMvc();
        }
    }
}
