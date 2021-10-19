using ConsumeForsquareAPI.Hubs;
using ConsumeForsquareAPI.Models;
using ConsumeForsquareAPI.Repositories;
using ConsumeForsquareAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI
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
            services.AddSignalR();
            services.AddDbContext<ForsquareContext>(o => o.UseSqlite("Data source=places.db"));
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IGetResponseService, GetResponseService>();
            services.AddScoped<ICreateRetrieveRequestService, CreateRetrieveRequestService>();
            services.AddSingleton<IHubClientSendService, HubClientSendService>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IForsquareResponseSearchService, ForsquareResponseSearchServicec>();
            services.AddHttpClient<IForsquareRequestService, ForsquareRequestService>(c => 
            {
                c.BaseAddress = new Uri("https://api.foursquare.com/v2/venues/");
            });
            //services.AddTransient<IForsquareRequestService, ForsquareRequestService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConsumeForsquareAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<RequestHub>("/reqHub");
                });

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsumeForsquareAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<RequestHub>("/reqHub");
            });
        }
    }
}
