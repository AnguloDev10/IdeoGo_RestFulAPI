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
using IdeoGo.API.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            ///JWT Auth Config
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            /////////////////////New

            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("IdeoGo-api-in-memory");
                options.UseSqlite(Configuration.GetConnectionString("MvcMovieContext"));
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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            
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
                    Description = "A IdeoGo API with ASP.NET Core Web API",
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

           

         
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ideogo.API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            ///CORS Config
            app.UseCors(x => x.
            AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();
            /////
            app.UseAuthentication();
            //////
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            


        }
    }
}
