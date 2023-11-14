using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal class ExerciseDbContext : DbContext
    {
        //this is the connection string to connect to the database
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public ExerciseDbContext() : base()
        {
        }
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options)
        {
           
        }
     

        public DbSet<Exercise> Exercises { get; set; }

        // Add other DbSet properties for additional entities, if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here if needed
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your options here if needed
            optionsBuilder.UseSqlServer(ConnectionString);
        }


    }
}
