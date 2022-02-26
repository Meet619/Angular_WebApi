using BackendWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Register> Registration { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<TeamInfo> TeamInfo { get; set; }
        public DbSet<TrainingPlan> TrainingPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamInfo>().HasData(
            new TeamInfo { Id = 1, MemberName = "Akash", DateOfJoining = new DateTime(1998, 12, 30)},
            new TeamInfo { Id = 2, MemberName = "Ramesh", DateOfJoining = new DateTime(1989, 09, 22) },
            new TeamInfo { Id = 3, MemberName = "Suresh", DateOfJoining = new DateTime(1993, 08, 10) }
            );

            modelBuilder.Entity<TrainingPlan>().HasData(
            new TrainingPlan { Id = 1, TrainingTopic = "DotNet", TrainingLocation = "Pluralsight" },
            new TrainingPlan { Id = 2, TrainingTopic = "APMTutorial", TrainingLocation = "LearningCenter" },
            new TrainingPlan { Id = 3, TrainingTopic = "Ethics", TrainingLocation = "Teams" }
            );
        }
    }
}
