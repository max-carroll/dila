using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DilaApplication;
using DilaRepository;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DilaAPI
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection"); //Environment.GetEnvironmentVariable("CONNECTION_STRING");



            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                });
            // services.AddEntityFrameworkNpgsql()




            services.AddSwaggerGen();
            services.AddEntityFrameworkNpgsql().AddDbContext<DilaDbContext>(opt =>
            opt.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("DilaAPI")
            ).UseLowerCaseNamingConvention()

            )

                ;

            services.AddScoped<IDilaContext, DilaDbContext>();
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWordService, WordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DilaDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            // using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            // {
            // https://stackoverflow.com/questions/42355481/auto-create-database-in-entity-framework-core/42356110
            // var context = serviceScope.ServiceProvider.GetRequiredService<DilaContext>();
            context.Database.Migrate();




        }
    }
}
