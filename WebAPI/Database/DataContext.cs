﻿using Microsoft.EntityFrameworkCore;

namespace WebAPI.Database
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private static string? ConnectionString;
        public DataContext() { }
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to SQL with connection string from app settings
            options.UseSqlServer(ConnectionString);
    }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
