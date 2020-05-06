using IdeoGo.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Persistences.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Entrepreneur> Enterpreneurs { get; set; }
        public DbSet<AccountSubscription> AccountSubscriptions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Memberchip> Memberships { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> User { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//padredacategory
            //CategoryEntity
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);//llave primaria
            builder.Entity<Category>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.projects).WithOne(p => p.Categories).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
                (
                new Category { Id = 100, Name = "Artes" },
                new Category { Id = 101, Name = "Tecnologia" }
                );
            builder.Entity<Project>().ToTable("Projects");
                       builder.Entity<Project>().HasKey(p => p.Id);
                       builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                        builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(50);
                        builder.Entity<Project>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            //builder.Entity<Project>().Property(p => p.Entrepreneur).IsRequired();
            //builder.Entity<Project>().HasMany(p => p.Collaborator).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);

            builder.Entity<Goal>().HasBaseType<Registry>();
         
            builder.Entity<Collaborator>().HasBaseType<User>();
            builder.Entity<Entrepreneur>().HasBaseType<User>();


            //builder.Entity<Account>().HasData(
            //    new Account { Id = 1, Key = "2c8bab3c-6050-4247-bba0-77777b088388", CreateAt = Convert.ToDateTime("2019-11-05"), Payment = true }
            //    );
            //builder.Entity<Subscription>().HasData(



            //new Subscription { Id = 1, Name = "Free", Description = 1, Price = 0.00M },
            //   new Subscription { Id = 2, Name = "Micro Entrepreneur", NumberUser = 6, Price = 12.90M },
            //   new Subscription { Id = 3, Name = "Entrepreneur", NumberUser = 20, Price = 35.90M },
            //   new Subscription { Id = 4, Name = "Advisor", NumberUser = 1, Price = 6.90M }
            //   );
        }



    }
}
