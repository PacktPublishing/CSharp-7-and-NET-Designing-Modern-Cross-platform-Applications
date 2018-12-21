using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Caching;
using Polly.Caching.MemoryCache;
using Polly.CircuitBreaker;
using Polly.Registry;
using Swashbuckle.AspNetCore.Swagger;
using UserRegService.Resilient;

namespace Chapter8
{
    public class Startup
    {

        private IPolicyRegistry<string> _registry;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {


                _registry = new PolicyRegistry();

                var circuitBreakerPolicy = Policy.HandleResult<HttpResponseMessage>(x=> {
                    var result = !x.IsSuccessStatusCode;    
                    return result;
                })
                .CircuitBreaker(3, TimeSpan.FromSeconds(60), OnBreak, OnReset, OnHalfOpen);
            // .AdvancedCircuitBreaker(0.1, TimeSpan.FromSeconds(60),5, TimeSpan.FromSeconds(10), OnBreak, OnReset, OnHalfOpen);


            //working
            //var circuitBreakerPolicy = Policy.Handle<AggregateException>(x =>
            //{
            //    var result = x.InnerException is HttpRequestException;
            //    System.Console.WriteLine("Circuit opened...");
            //    return result;
            //})
            //.CircuitBreaker(exceptionsAllowedBeforeBreaking: 3, durationOfBreak: TimeSpan.FromSeconds(50));

            services.AddHealthChecks(checks =>
            {
                checks.AddValueTaskCheck("HTTP Endpoint", () => new
                    ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
            });

            services.AddSingleton<HttpClient>();

                services.AddSingleton(_registry);
                services.AddSingleton<CircuitBreakerPolicy<HttpResponseMessage>>(circuitBreakerPolicy);
            
                //working
                //services.AddSingleton<CircuitBreakerPolicy>(circuitBreakerPolicy);
                services.AddSingleton<IResilientHttpClient, ResilientHttpClient>();
                services.AddMvc();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "User Service", Version = "v1" });
                });
            }

        private void OnBreak(DelegateResult<HttpResponseMessage> arg1, TimeSpan arg2)
        {
            //Log to file system
        }
        private void OnReset()
        {
            //log to file system
        }
        private void OnHalfOpen()
        {
            // log to file system
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMemoryCache memoryCache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Polly.Caching.MemoryCache.MemoryCacheProvider memoryCacheProvider = new MemoryCacheProvider(memoryCache);

            CachePolicy<HttpResponseMessage> cachePolicy = Policy.Cache<HttpResponseMessage>(memoryCacheProvider, TimeSpan.FromMinutes(10));

            _registry.Add("cache", cachePolicy);

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API V1");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
