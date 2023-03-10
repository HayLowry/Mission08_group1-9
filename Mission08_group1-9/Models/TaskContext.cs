using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_group1_9.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<Tasko> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        // seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Church"
                }
                );

            mb.Entity<Tasko>().HasData(
                new Tasko
                {
                    TaskId = 1,
                    TaskTitle = "My First Task",
                    DueDate = "2023-02-25",
                    Completed = false,
                    CategoryId = 1,
                    Urgent = false,
                    Important = false
                }
            );
        }
    }
}
