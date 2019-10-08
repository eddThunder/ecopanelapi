
using Domain.Services.Interfaces;
using Domain.Services.RoleService;
using Domain.Services.UserService;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace ecopanelAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //Add serilog startup configuration...
            Log.Logger = new LoggerConfiguration()
                       .MinimumLevel.Error().WriteTo.File("Log.txt")
                       .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Infrastructure 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RolesRepository>();

            //Domain 
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Ecopane API",
                    Description = "Ecopanel Swagger",
                    TermsOfService = "None"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseHsts();
            }

            //Adding serilog to the logger wrapper
            loggerFactory.AddSerilog();

            app.UseHttpsRedirection();
            app.UseMvc();

            // Swagger...
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
