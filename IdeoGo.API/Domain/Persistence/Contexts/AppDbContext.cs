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

        public DbSet<Appoitment> Appoitments { get; set; }
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
               { Id = 1, Name = "Informatica" },
               new Category
               { Id = 2, Name = "Deportes" },
               new Category
               { Id = 3, Name = "Derecho" },
               new Category
               { Id = 4, Name = "Ciencia" },
               new Category
               { Id = 5, Name = "Gastronomia" },
               new Category
               { Id = 6, Name = "Cocina" },
               new Category
               { Id = 7, Name = "Tecnologia" }
           );
            //TagEntity
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Tag>().HasMany(p => p.Skills).WithOne(p => p.Tag).HasForeignKey(p => p.TagId);
            builder.Entity<Tag>().HasMany(p => p.UserProfiles).WithOne(p => p.Tag).HasForeignKey(p => p.TagId);
            // builder.Entity<Tag>().HasMany(p => p.Projects).WithOne(p => p.Tag).HasForeignKey(p => p.TagId);
            builder.Entity<Tag>().HasData(
                new Tag
                { Id = 1, Name = "ut", CategoryId = 4 },
                new Tag
                { Id = 2, Name = "ante", CategoryId = 1 },
                new Tag
                { Id = 3, Name = "nascetur", CategoryId = 4 },
                new Tag
                { Id = 4, Name = "dis", CategoryId = 2 },
                new Tag
                { Id = 5, Name = "accumsan", CategoryId = 2 },
                new Tag
                { Id = 6, Name = "sit", CategoryId = 5 },
                new Tag
                { Id = 7, Name = "tellus", CategoryId = 1 }
            );

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
            builder.Entity<Profile>().HasData(

                new Profile
                { Id = 1, Name = "Lek Mitchenson", Gender = EGender.Masculino, Occupation = "Nuclear Power Engineer", Age = 24, TypeUser = "Colaborator", UserId = 1, TagId = 4 },
                new Profile
                { Id = 2, Name = "Ly Seakin", Gender = EGender.Femenino, Occupation = "Senior Financial Analyst", Age = 23, TypeUser = "Colaborator", UserId = 2, TagId = 6 },
                new Profile
                { Id = 3, Name = "Anson Harmston", Gender = EGender.Femenino, Occupation = "Senior Quality Engineer", Age = 22, TypeUser = "Enterperneur", UserId = 3, TagId = 6 },
                new Profile
                { Id = 4, Name = "Jandy Krugmann", Gender = EGender.Femenino, Occupation = "Geologist I", Age = 20, TypeUser = "Colaborator", UserId = 4, TagId = 4 },
                new Profile
                { Id = 5, Name = "Osborn Deetlefs", Gender = EGender.Masculino, Occupation = "Research Assistant III", Age = 25, TypeUser = "Enterperneur", UserId = 5, TagId = 7 }

            );
            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Datesignup).IsRequired();
            builder.Entity<User>().HasMany(p => p.Applications).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.Entity<User>().HasMany(p => p.Subscriptions).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.Entity<User>().HasMany(p => p.Memberships).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.Entity<User>().HasData
            (
               new User
               { Id = 1, Email = "kjahndel0@google.ca", Password = "s23Xilmj", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) },
               new User
               { Id = 2, Email = "deede1@techcrunch.com", Password = "gAni3Cb", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) },
               new User
               { Id = 3, Email = "dcurrie2@typepad.com", Password = "gAni3Cb", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) },
               new User
               { Id = 4, Email = "mhalsworth3@aboutads.info", Password = "gAni3Cb", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) },
               new User
               { Id = 5, Email = "cgodlee4@purevolume.com", Password = "gAni3Cb", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) },
               new User
               { Id = 6, Email = "user@techcrunch.com", Password = "gAni3Cb", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52) }

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
            builder.Entity<ProjectSchedule>().HasData(
                new ProjectSchedule
                { Id = 1, Name = "tkettlestringes0", Description = "imperdiet", ProjectId = 1 },
                new ProjectSchedule
                { Id = 2, Name = "mdelavaletteparisot1", Description = "neque vestibulum eget", ProjectId = 2 },
                new ProjectSchedule
                { Id = 3, Name = "passel2", Description = "nulla eget", ProjectId = 3 },
                new ProjectSchedule
                { Id = 4, Name = "tpawfoot3 ", Description = "nulla", ProjectId = 4 },
                new ProjectSchedule
                { Id = 5, Name = "tkettlestringes0", Description = "consequat morbi", ProjectId = 5 }
            );
            //Goal Entity
            builder.Entity<Goal>().ToTable("Goals");
            builder.Entity<Goal>().HasKey(p => p.Id);
            builder.Entity<Goal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Goal>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Goal>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            //builder.Entity<Goal>().Property(p => p.EstimatedDate).IsRequired();
            builder.Entity<Goal>().HasData(
                new Goal
                { Id = 1, Name = "Sharable explicit", Description = "habitasse platea dictumst", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 4 },
                new Goal
                { Id = 2, Name = "Profit-focused", Description = "ut ultrices vel", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 2 },
                new Goal
                { Id = 3, Name = "Cloned leading", Description = "rutrum rutrum neque aenean", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 5 },
                new Goal
                { Id = 4, Name = "Profound scalable ", Description = "eu tincidunt in", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 5 },
                new Goal
                { Id = 5, Name = "Operative internet ", Description = "hac habitasse", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 4 },
                new Goal
                { Id = 6, Name = "Triple architecture", Description = "amet nunc viverra dapibus", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 2 },
                new Goal
                { Id = 7, Name = "Pre-emptive model", Description = "pellentesque viverra pede", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 4 },
                new Goal
                { Id = 8, Name = "Reduced extranet", Description = "lorem ipsum", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 4 },
                new Goal
                { Id = 9, Name = "Re-engineered archive", Description = "vivamus tortor", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 4 },
                new Goal
                { Id = 10, Name = "Monitored structure", Description = "euismod scelerisque quam turpis", EstimatedDate = new DateTime(2020, 5, 1, 8, 30, 52), ProjectId = 2 }
            );
            //Activity Entity
            builder.Entity<Activity>().ToTable("Activities");
            builder.Entity<Activity>().HasKey(p => p.Id);
            builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Activity>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Activity>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Activity>().HasData(
                new Activity
                { Id = 1, Name = "Cloned set", Description = "donec odio justo sollicitudin ut suscipit", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 2, Name = "Persistent product", Description = "lectus pellentesque at nulla suspendisse potenti", ProjectScheduleId = 4, projectId = 4 },
                new Activity
                { Id = 3, Name = "Cross-platform architecture", Description = "imperdiet et commodo vulputate justo in", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 4, Name = "Up-sized groupware", Description = "sagittis nam congue risus semper porta    ", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 5, Name = "Up-sized hub", Description = "a pede posuere nonummy integer non", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 6, Name = "Vision management ", Description = "a feugiat et eros vestibulum ac   ", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 7, Name = "Artificial intelligence", Description = "nec molestie sed justo pellentesque viverra", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 8, Name = "Mandatory forecast", Description = "egestas metus aenean fermentum donec ut", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 9, Name = "Up-sized access", Description = "duis consequat dui nec nisi volutpat", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 10, Name = "Pre-emptive matrix", Description = "turpis sed ante vivamus tortor duis", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 11, Name = "Re-engineered network    ", Description = "at nibh in hac habitasse platea", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 12, Name = "Balanced productivity", Description = "eu est congue elementum in hac", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 13, Name = "Reverse hierarchy", Description = "molestie lorem quisque ut erat curabitur", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 14, Name = "Public-key  software", Description = "aliquam quis turpis eget elit sodales", ProjectScheduleId = 1, projectId = 1 },
                new Activity
                { Id = 15, Name = "Enterprise", Description = "blandit ultrices enim lorem ipsum dolor", ProjectScheduleId = 1, projectId = 1 }
            );
            //Task
            builder.Entity<Domain.Models.MTask>().ToTable("Tasks");
            builder.Entity<Domain.Models.MTask>().HasKey(p => p.Id);
            builder.Entity<Domain.Models.MTask>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Domain.Models.MTask>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Domain.Models.MTask>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Domain.Models.MTask>().Property(p => p.DeliveryDate).IsRequired();
            builder.Entity<MTask>().HasData
            (
            new MTask
            { Id = 1, Name = "Tarea 1", Description = "Cumplir esta Tarea 1", DeliveryDate = new DateTime(2020, 1, 2, 7, 30, 52), ProjectScheduleId = 5, ProjectId = 5 },
            new MTask
            { Id = 2, Name = "Tarea 2", Description = "Cumplir este Tarea 2", DeliveryDate = new DateTime(2020, 1, 2, 8, 30, 52), ProjectScheduleId = 1, ProjectId = 1 },
            new MTask
            { Id = 3, Name = "Tarea 3", Description = "Cumplir esta Tarea 3", DeliveryDate = new DateTime(2020, 2, 5, 9, 30, 52), ProjectScheduleId = 4, ProjectId = 4 },
            new MTask
            { Id = 4, Name = "Tarea 4", Description = "Cumplir esta Tarea 4", DeliveryDate = new DateTime(2020, 2, 5, 10, 30, 52), ProjectScheduleId = 1, ProjectId = 1 },
            new MTask
            { Id = 5, Name = "Tarea 5", Description = "Cumplir esta Tarea 5", DeliveryDate = new DateTime(2020, 3, 6, 11, 30, 52), ProjectScheduleId = 5, ProjectId = 5 },
            new MTask
            { Id = 6, Name = "Tarea 6", Description = "Cumplir esta Tarea 6", DeliveryDate = new DateTime(2020, 3, 6, 12, 30, 52), ProjectScheduleId = 4, ProjectId = 4 },
            new MTask
            { Id = 7, Name = "Tarea 7", Description = "Cumplir esta Tarea 7", DeliveryDate = new DateTime(2020, 3, 6, 12, 30, 52), ProjectScheduleId = 3, ProjectId = 3 },
            new MTask
            { Id = 8, Name = "Tarea 7", Description = "Cumplir esta Tarea 7", DeliveryDate = new DateTime(2020, 3, 6, 12, 30, 52), ProjectScheduleId = 4, ProjectId = 4 }
            );

            //Appoitment
            builder.Entity<Domain.Models.Appoitment>().ToTable("Appotiments");
            builder.Entity<Domain.Models.Appoitment>().HasKey(p => p.Id);
            builder.Entity<Domain.Models.Appoitment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Domain.Models.Appoitment>().Property(p => p.Date).IsRequired().HasMaxLength(30);
            //builder.Entity<Appoitment>().HasData
            //    (
            //    new Appoitment
            //    { Id = 100, Date = new DateTime(2020, 1, 2, 7, 30, 52) },
            //    new Appoitment
            //    { Id = 101, Date = new DateTime(2020, 5, 2, 7, 30, 52) },
            //    new Appoitment
            //    { Id = 102, Date = new DateTime(2020, 4, 3, 8, 30, 52) },
            //    new Appoitment
            //    { Id = 103, Date = new DateTime(2020, 4, 2, 6, 30, 52) },
            //    new Appoitment
            //    { Id = 104, Date = new DateTime(2020, 6, 1, 5, 30, 52) },
            //    new Appoitment
            //    { Id = 105, Date = new DateTime(2020, 6, 1, 7, 30, 52) }
            //    );


            /////////////Sergio

            //Requierements
            builder.Entity<Requierement>().ToTable("Requierements");
            builder.Entity<Requierement>().HasKey(p => p.Id);
            builder.Entity<Requierement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Requierement>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Requierement>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            //builder.Entity<Requierement>().HasOne(p => p.Project).WithMany(p => p.Requierements).HasForeignKey(p => p.ProjectId);
            builder.Entity<Requierement>().HasData
            (
                new Requierement
                { Id = 1, Name = "Requierement 1", Description = "Cumplir con el Requierement 1", ProjectId = 1 },
                new Requierement
                { Id = 2, Name = "Requierement 2", Description = "Cumplir con el Requierement 2", ProjectId = 5 },
                new Requierement
                { Id = 3, Name = "Requierement 3", Description = "Cumplir con el Requierement 3", ProjectId = 2 },
                new Requierement
                { Id = 4, Name = "Requierement 4", Description = "Cumplir con el Requierement 4", ProjectId = 4 },
                new Requierement
                { Id = 5, Name = "Requierement 5", Description = "Cumplir con el Requierement 5", ProjectId = 3 },
                new Requierement
                { Id = 6, Name = "Requierement 6", Description = "Cumplir con el Requierement 6", ProjectId = 1 },
                new Requierement
                { Id = 7, Name = "Requierement 6", Description = "Cumplir con el Requierement 6", ProjectId = 5 }
            );
            //Resources
            builder.Entity<Resource>().ToTable("Resources");
            builder.Entity<Resource>().HasKey(p => p.Id);
            builder.Entity<Resource>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Resource>().Property(p => p.Quantity).IsRequired();
            builder.Entity<Resource>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Resource>().HasData
                (
   
                    new Resource
                    { Id = 1, Quantity = 50 ,UnitOfMeasurement = EUnitOfMeasurement.Milligram },
                    new Resource
                    { Id = 2, Quantity = 200, UnitOfMeasurement = EUnitOfMeasurement.Liter },
                    new Resource
                    { Id = 3, Quantity = 100, UnitOfMeasurement = EUnitOfMeasurement.Milligram },
                    new Resource
                    { Id = 4, Quantity = 300, UnitOfMeasurement = EUnitOfMeasurement.Gram },
                    new Resource
                    { Id = 5, Quantity = 250, UnitOfMeasurement = EUnitOfMeasurement.Milligram },
                    new Resource
                    { Id = 6, Quantity = 150, UnitOfMeasurement = EUnitOfMeasurement.Liter },
                    new Resource
                    { Id = 7, Quantity = 150, UnitOfMeasurement = EUnitOfMeasurement.Milligram }
                );
            //skills
            builder.Entity<Skill>().ToTable("Skills");
            builder.Entity<Skill>().HasKey(p => p.Id);
            builder.Entity<Skill>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Skill>().Property(p => p.DegreesRequired).IsRequired().HasMaxLength(30);
            builder.Entity<Skill>().HasOne(p => p.UserProfile).WithMany(p => p.Skills).HasForeignKey(p => p.UserProfileId);
            builder.Entity<Skill>().HasOne(p => p.Tag).WithMany(p => p.Skills).HasForeignKey(p => p.TagId);
            builder.Entity<Skill>().HasData
            (
            new Skill
            { Id = 1, DegreesRequired = "Programacion" ,UserProfileId=3,TagId=2},
            new Skill
            { Id = 2, DegreesRequired = "Arquitectura de software", UserProfileId = 5, TagId = 4 },
            new Skill
            { Id = 3, DegreesRequired = "Base de datos", UserProfileId = 1, TagId = 5 },
            new Skill
            { Id = 4, DegreesRequired = "Diseño de planos", UserProfileId = 1, TagId = 1 },
            new Skill
            { Id = 5, DegreesRequired = "Investigación Economica", UserProfileId = 3, TagId = 6 },
            new Skill
            { Id = 6, DegreesRequired = "Investigación Biologia", UserProfileId = 4, TagId = 3 },
            new Skill
            { Id = 7, DegreesRequired = "Web Developer III", UserProfileId = 5, TagId = 7 }
            );
             //Applications

            builder.Entity<Application>().ToTable("Applications");
            builder.Entity<Application>().HasKey(p => p.Id);
            builder.Entity<Application>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Application>().Property(p => p.OrderRequest).IsRequired();
            builder.Entity<Application>().Property(p => p.State).IsRequired().HasMaxLength(30);
            builder.Entity<Application>().Property(p => p.DateSend).IsRequired();
            //builder.Entity<Application>().HasOne(p => p.User).WithMany(p => p.Applications).HasForeignKey(p => p.UserId);
            //builder.Entity<Application>().HasOne(p => p.Project).WithMany(p => p.Applications).HasForeignKey(p => p.ProjectId);
            builder.Entity<Application>().HasData
            (
            new Application
            { Id = 1, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2020, 3, 6, 11, 30, 52),UserId=3,ProjectId=5 },
            new Application
            { Id = 2, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 3, 6, 7, 30, 52), UserId = 5, ProjectId = 3 },
            new Application
            { Id = 3, OrderRequest = 5, State = "Culminado", DateSend = new DateTime(2019, 4, 5, 4, 30, 52), UserId = 3, ProjectId = 3 },
            new Application
            { Id = 4, OrderRequest = 5, State = "Culminado", DateSend = new DateTime(2019, 5, 2, 5, 30, 52), UserId = 5, ProjectId = 3 },
            new Application
            { Id = 5, OrderRequest = 5, State = "Culminado", DateSend = new DateTime(2019, 6, 3, 10, 30, 52), UserId = 4, ProjectId = 5 },
            new Application
            { Id = 6, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 1, ProjectId = 1 },
            new Application
            { Id = 7, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 3, ProjectId = 1 },
            new Application
            { Id = 8, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 5, ProjectId = 4 },
            new Application
            { Id = 9, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 4, ProjectId = 3 },
            new Application
            { Id = 10, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 1, ProjectId = 2 },
            new Application
            { Id = 11, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 3, ProjectId = 3 },
            new Application
            { Id = 12, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 2, ProjectId = 3 },
            new Application
            { Id = 13, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 3, ProjectId = 1 },
            new Application
            { Id = 14, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 4, ProjectId = 3 },
            new Application
            { Id = 15, OrderRequest = 5, State = "En proceso", DateSend = new DateTime(2019, 7, 7, 9, 30, 52), UserId = 4, ProjectId = 1 }
            );
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
            builder.Entity<Project>().HasData(
               new Project
               { Id=1,Name= "Stronghold", Description= "vitae", ProjectLeaderId=1,DateCreated= new DateTime(2019, 7, 7, 9, 30, 52), TagId=2 },
               new Project
               { Id = 2, Name = "Tresom", Description = "proin", ProjectLeaderId = 4, DateCreated = new DateTime(2019, 7, 7, 9, 30, 52), TagId = 2 },
               new Project
               { Id = 3, Name = "Span", Description = "id massa id", ProjectLeaderId = 1, DateCreated = new DateTime(2019, 7, 7, 9, 30, 52), TagId = 1 },
               new Project
               { Id = 4, Name = "Y-find", Description = "ultrices posuere cubilia", ProjectLeaderId = 3, DateCreated = new DateTime(2019, 7, 7, 9, 30, 52), TagId = 3 },
               new Project
               { Id = 5, Name = "Flowdesk", Description = "libero nam", ProjectLeaderId = 2, DateCreated = new DateTime(2019, 7, 7, 9, 30, 52), TagId = 6 }
            );
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
            //builder.Entity<ProjectTag>().HasData(
            //    new ProjectTag
            //    { ProjectId = 1, TagId = 5},
            //    new ProjectTag
            //    { ProjectId = 4, TagId = 5 },
            //    new ProjectTag
            //    { ProjectId = 1, TagId = 3 },
            //    new ProjectTag
            //    { ProjectId = 4, TagId = 6 },
            //    new ProjectTag
            //    { ProjectId = 4, TagId = 7 },
            //    new ProjectTag
            //    { ProjectId = 2, TagId = 1 },
            //    new ProjectTag
            //    { ProjectId = 2, TagId = 5 },
            //    new ProjectTag
            //    { ProjectId = 5, TagId = 3 }
            //    );

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
            //builder.Entity<ProjectUser>().HasData(
            //    new ProjectUser
            //    { ProjectId = 1, UserId = 2, Role= ERole.Owner},
            //    new ProjectUser
            //    { ProjectId = 4, UserId = 4, Role = ERole.Member },
            //    new ProjectUser
            //    { ProjectId = 4, UserId = 1, Role = ERole.Owner },
            //    new ProjectUser
            //    { ProjectId = 4, UserId = 3, Role = ERole.Member },
            //    new ProjectUser
            //    { ProjectId = 2, UserId = 3, Role = ERole.Advisor },
            //    new ProjectUser
            //    { ProjectId = 2, UserId = 4, Role = ERole.Advisor },
            //    new ProjectUser
            //    { ProjectId = 5, UserId = 5, Role = ERole.Owner },
            //    new ProjectUser
            //    { ProjectId = 1, UserId = 4, Role = ERole.Owner }
            //    );

            // builder.Entity<Subscription>().HasData(
            //    new Subscription { Id = 1, Name = "Free", NumberUser = 1, Price = 0.00M },
            //    new Subscription { Id = 2, Name = "Micro Entrepreneur", NumberUser = 6, Price = 12.90M },
            //    new Subscription { Id = 3, Name = "Entrepreneur", NumberUser = 20, Price = 35.90M },
            //    new Subscription { Id = 4, Name = "Advisor", NumberUser = 1, Price = 6.90M }
            //    );
            //

            builder.ApplySnakeCaseNamingConvention();
        }



    }
}
