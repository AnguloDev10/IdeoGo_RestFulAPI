using IdeoGo.API.Domain.Models;
using IdeoGo.API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Requierement> Requierements { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Application> Aplications { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


        public DbSet<ProjectSchedule> ProjectsSchedules { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Domain.Models.MTask> Tasks { get; set; }




        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//padre


            /////Ricardo

            //CategoryEntity
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);//llave primaria
            builder.Entity<Category>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Tags).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>().HasData
            (
                new Category
                { Id = 100, Name = "Cocina" },
                new Category
                { Id = 101, Name = "Tecnologia" }
            );

            //TagEntity
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Tag>().HasMany(p => p.Skills).WithOne(p => p.Tag).HasForeignKey(p => p.TagId);
            builder.Entity<Tag>().HasMany(p => p.UserProfiles).WithOne(p => p.Tag).HasForeignKey(p => p.TagId);
            // builder.Entity<Tag>().HasMany(p => p.Projects).WithOne(p => p.Tag).HasForeignKey(p => p.TagId);


            //UserProfile Entity
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<Profile>().Property(p => p.Gender).IsRequired();
            builder.Entity<Profile>().Property(p => p.Occupation).IsRequired().HasMaxLength(80);
            builder.Entity<Profile>().Property(p => p.Age).IsRequired();
            builder.Entity<Profile>().Property(p => p.TypeUser).IsRequired().HasMaxLength(20);
            builder.Entity<Profile>().HasMany(p => p.Skills).WithOne(p => p.UserProfile).HasForeignKey(p => p.UserProfileId);

            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Datesignup).IsRequired();
            builder.Entity<User>().HasMany(p => p.Applications).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.Entity<User>().HasData
            (
               new User
               { Id = 100, Email = "emailnumber1", Password = "1234", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) },
               new User
               { Id = 101, Email = "anonymousisback", Password = "4321", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) }
           );

            /////////////Arvin

            //ProjectSchedule Entity
            builder.Entity<ProjectSchedule>().ToTable("ProjectSchedules");
            builder.Entity<ProjectSchedule>().HasKey(p => p.Id);
            builder.Entity<ProjectSchedule>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ProjectSchedule>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<ProjectSchedule>().Property(p => p.Description).IsRequired().HasMaxLength(100);


            builder.Entity<ProjectSchedule>().HasMany(p => p.Tasks).WithOne(p => p.ProjectSchedule).HasForeignKey(p => p.ProjectScheduleId);
            builder.Entity<ProjectSchedule>().HasMany(p => p.Activities).WithOne(p => p.ProjectSchedule).HasForeignKey(p => p.ProjectScheduleId);

            //Goal Entity
            builder.Entity<Goal>().ToTable("Goals");
            builder.Entity<Goal>().HasKey(p => p.Id);
            builder.Entity<Goal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Goal>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Goal>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            //builder.Entity<Goal>().Property(p => p.EstimatedDate).IsRequired();

            //Activity Entity
            builder.Entity<Activity>().ToTable("Activities");
            builder.Entity<Activity>().HasKey(p => p.Id);
            builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Activity>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Activity>().Property(p => p.Description).IsRequired().HasMaxLength(100);

            //Task
            builder.Entity<Domain.Models.MTask>().ToTable("Tasks");
            builder.Entity<Domain.Models.MTask>().HasKey(p => p.Id);
            builder.Entity<Domain.Models.MTask>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Domain.Models.MTask>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Domain.Models.MTask>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Domain.Models.MTask>().Property(p => p.DeliveryDate).IsRequired();


            /////////////Sergio

            //Requierements
            builder.Entity<Requierement>().ToTable("Requierements");
            builder.Entity<Requierement>().HasKey(p => p.Id);
            builder.Entity<Requierement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Requierement>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Requierement>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            //builder.Entity<Requierement>().HasOne(p => p.Project).WithMany(p => p.Requierements).HasForeignKey(p => p.ProjectId);

            //Resources
            builder.Entity<Resource>().ToTable("Resources");
            builder.Entity<Resource>().HasKey(p => p.Id);
            builder.Entity<Resource>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Resource>().Property(p => p.Quantity).IsRequired();
            builder.Entity<Resource>().Property(p => p.UnitOfMeasurement).IsRequired();

            //skills
            builder.Entity<Skill>().ToTable("Skills");
            builder.Entity<Skill>().HasKey(p => p.Id);
            builder.Entity<Skill>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Skill>().Property(p => p.DegreesRequired).IsRequired().HasMaxLength(30);
            builder.Entity<Skill>().HasOne(p => p.UserProfile).WithMany(p => p.Skills).HasForeignKey(p => p.UserProfileId);
            builder.Entity<Skill>().HasOne(p => p.Tag).WithMany(p => p.Skills).HasForeignKey(p => p.TagId);

            //Applications

            builder.Entity<Application>().ToTable("Applications");
            builder.Entity<Application>().HasKey(p => p.Id);
            builder.Entity<Application>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Application>().Property(p => p.OrderRequest).IsRequired();
            builder.Entity<Application>().Property(p => p.State).IsRequired().HasMaxLength(30);
            builder.Entity<Application>().Property(p => p.DateSend).IsRequired();
            //builder.Entity<Application>().HasOne(p => p.User).WithMany(p => p.Applications).HasForeignKey(p => p.UserId);
            //builder.Entity<Application>().HasOne(p => p.Project).WithMany(p => p.Applications).HasForeignKey(p => p.ProjectId);

            //Memberships
            builder.Entity<Membership>().ToTable("Memberships");
            builder.Entity<Membership>().HasKey(p => p.Id);
            builder.Entity<Membership>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Membership>().Property(p => p.StartAt).IsRequired();
            builder.Entity<Membership>().Property(p => p.EndAt).IsRequired();

            //Subscriptions
            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Name).IsRequired();
            builder.Entity<Subscription>().Property(p => p.Price).IsRequired();
            builder.Entity<Subscription>().Property(p => p.NumberUser).IsRequired();


            ////William

            // Project Entity

            builder.Entity<Project>().ToTable("Project");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Project>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Entity<Project>().Property(P => P.DateCreated).IsRequired();
            builder.Entity<Project>().HasMany(p => p.Applications).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);
            builder.Entity<Project>().HasMany(p => p.Goals).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);
            builder.Entity<Project>().HasMany(p => p.Requierements).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);

            // ProjectTag Entity

            builder.Entity<ProjectTag>().ToTable("ProjectTags");
            builder.Entity<ProjectTag>()
            .HasKey(pt => new { pt.ProjectId, pt.TagId });

            builder.Entity<ProjectTag>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTags)
                .HasForeignKey(pt => pt.ProjectId);

            builder.Entity<ProjectTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProjectTags)
                .HasForeignKey(pt => pt.TagId);


            // ProjectUser Entity




            builder.Entity<ProjectUser>().ToTable("ProjectUsers");
            builder.Entity<ProjectUser>()
            .HasKey(pt => new { pt.ProjectId, pt.UserId });

            builder.Entity<ProjectUser>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pt => pt.ProjectId);

            builder.Entity<ProjectUser>()
                .HasOne(pt => pt.User)
                .WithMany(t => t.ProjectUsers)
                .HasForeignKey(pt => pt.UserId);


            builder.Entity<Subscription>().HasData(
               new Subscription { Id = 1, Name = "Free", NumberUser = 1, Price = 0.00M },
               new Subscription { Id = 2, Name = "Micro Entrepreneur", NumberUser = 6, Price = 12.90M },
               new Subscription { Id = 3, Name = "Entrepreneur", NumberUser = 20, Price = 35.90M },
               new Subscription { Id = 4, Name = "Advisor", NumberUser = 1, Price = 6.90M }
               );


            builder.ApplySnakeCaseNamingConvention();
        }



    }
}
