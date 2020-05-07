using IdeoGo.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistences.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Entrepreneur> Enterpreneurs { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Memberchip> Memberships { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//padre
            //CategoryEntity
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);//llave primaria
            builder.Entity<Category>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.projects).WithOne(p => p.Categories).HasForeignKey(p => p.CategoryId);
                           
            builder.Entity<Category>().HasData
                (
                new Goal { Id = 100, Name = "Artes" },
                new Goal { Id = 101, Name = "Tecnologia" }
                );

            //ProjectEntity
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Project>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            //builder.Entity<Project>().Property(p => p.user);
            builder.Entity<Project>().Property(p => p.userId);
            //builder.Entity<Project>().Property(p => p.Entrepreneur).IsRequired();
            //builder.Entity<Project>().HasMany(p => p.Collaborator).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);


            builder.Entity<Publication>().ToTable("Publication");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Publication>().Property(p => p.Body).IsRequired().HasMaxLength(150);
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Publication>().Property(p => p.CreateAt).IsRequired();
            //builder.Entity<Publication>().Property(p => p.Entrepreneur);


            builder.Entity<Tag>().ToTable("Tag");
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Tag>().HasMany(p => p.Projects).WithOne(p => p.tag).HasForeignKey(p => p.tagId);


            builder.Entity<Goal>().ToTable("Goal");
            builder.Entity<Goal>().HasKey(p => p.Id);
            builder.Entity<Goal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Goal>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Goal>().Property(p => p.Description).IsRequired().HasMaxLength(50);


            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            //builder.Entity<User>().Property(p => p.Gender);
            builder.Entity<User>().Property(p => p.Occupation).IsRequired().HasMaxLength(80);
            builder.Entity<User>().Property(p => p.Experience).IsRequired().HasMaxLength(100);
           // builder.Entity<User>().HasMany(p => p.Projects).WithOne(p => p.user).HasForeignKey(p => p.userId);
        }



    }
}
