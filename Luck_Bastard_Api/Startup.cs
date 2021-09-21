using Data_Access.DBContext;
using Data_Access.Features;
using Data_Access.Helpers;
using Data_Access.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Luck_Bastard_Api
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.AddDbContext<MyDBContext>(options =>
            {
               options.UseSqlServer("Data Source=188.121.44.217; Initial Catalog=ph10150450451_lb;user id=Lucky_bastard;password=&200cjtP").EnableSensitiveDataLogging()
         ;
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddMediatR(typeof(GetAllUsersQuery).Assembly);
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<MyDBContext>();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddSignalR();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Luck_Bastard_Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });
  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Luck_Bastard_Api v1"));
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
          
            app.UseRouting();
            app.UseSession();
            app.UseCors("SlotPolicy");
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors(options => options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMiddleware<JwTMiddleWare>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SignalRHub>("/hub");
                endpoints.MapControllers();
            });
        }
    }
}
