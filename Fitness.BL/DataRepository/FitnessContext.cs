using Fitness.BL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness.BL.DataRepository
{
    class FitnessContext:DbContext
    {
        public FitnessContext()
        {
            //Database.EnsureCreated();//проверить асинхронность
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection"));
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
        }*/
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
