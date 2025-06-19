using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;
using WebApplication1Api.Models;

namespace WebApplication1Api.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
