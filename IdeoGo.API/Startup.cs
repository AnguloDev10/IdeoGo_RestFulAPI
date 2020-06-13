using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using AutoMapper;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Persistence.Repositories;
using IdeoGo.API.Services;
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
using FluentAssertions.Common;

namespace IdeoGo.API
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
            services.AddControllers();


            /////////////////////New

            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("IdeoGo-api-in-memory");
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRequierementRepository, RequierementRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();


            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectTagRepository, ProjectTagRepository>();
            services.AddScoped<IProjectUserRepository, ProjectUserRepository>();

            services.AddScoped<IProjectScheduleRepository, ProjectScheduleRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IMTaskRepository, MTaskRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IRequierementService, RequierementService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectTagService, ProjectTagService>();
            services.AddScoped<IProjectUserService, PRojectUserService>();
            services.AddScoped<IProjectScheduleService, ProjectScheduleService>();
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IMTaskService, MTaskService>();


            services.AddAutoMapper(typeof(Startup));


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://www.gmail.com/wmavalle"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });



            /////////////////
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

         
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ideogo.API V1");
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            


        }
    }
}
