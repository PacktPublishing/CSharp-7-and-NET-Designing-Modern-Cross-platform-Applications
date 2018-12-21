using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SecurityApp
{
    public class Startup
    {
        IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(config =>
            {
                //Allow only HTTP GET Requests
                config.AddPolicy("AllowOnlyGet", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.WithMethods("GET");
                    builder.AllowAnyOrigin();
                });

                //Allow only those requests coming from techframeworx.com
                config.AddPolicy("Techframeworx", builder => {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.WithOrigins("http://techframeworx.com");
                });
            });

            


            services.AddMvc(options => {
                options.Filters.Add(new RequireHttpsAttribute());
                if (!_env.IsProduction())
                {
                    options.SslPort = 44326;
                }
            });

         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
