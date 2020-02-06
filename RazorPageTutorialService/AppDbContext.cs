using Microsoft.EntityFrameworkCore;
using RazorPageTutorialModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPageTutorialService
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
