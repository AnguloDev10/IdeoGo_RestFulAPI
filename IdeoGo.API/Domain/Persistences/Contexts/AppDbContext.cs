using IdeoGo.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Persistences
{
    public class AppDbContext: DbContext
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
        public DbSet<User> User { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) {}

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

        }



    }
}
