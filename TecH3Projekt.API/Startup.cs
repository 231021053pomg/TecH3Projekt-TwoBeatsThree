using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;//
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;//
using TecH3Projekt.API.Repositories;//
using TecH3Projekt.API.Services;//
using Newtonsoft.Json;//

namespace TecH3Projekt.API
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_AllowSpecificOrigins";//

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // CORS configuration needed in order to allow our angular app to communicate with server
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .WithMethods("GET", "POST", "PUT", "DELETE");
                    });
            });


            services.AddDbContext<TecH3ProjectDbContext>(//
                options => options.UseSqlServer(Configuration.GetConnectionString("ProjectConnection"))
                );

            //Scopes for Repos NEEDED for injection implemintation in services.
            services.AddScoped<ILogInRepository, LogInRepository>();
            services.AddScoped<IUserRepository, UserRepository>();//
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();// <------------
            services.AddScoped<IPictureRepository, PictureRepository>();//
            services.AddScoped<ITypeRepository, TypeRepository>();//


            //Scopes for Services NEEDED for injection implemintation in controllers.
            services.AddScoped<ILogInService, LogInService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IProductService, ProductService>();// <------------


            /////////////////
            services.AddControllers()
                .AddNewtonsoftJson(options => //Used to handle looping reference issues.
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TecH3Projekt.API", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TecH3Projekt.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);//

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
