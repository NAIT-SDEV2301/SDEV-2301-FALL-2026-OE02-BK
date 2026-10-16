namespace Module02.Lesson16
{
   // EfCoreSetupDemo_Solution.cs
	// Completed solution for: DbContext, entity, configuration, seeding, and a basic query.
	//
	// Required NuGet packages:
	//   - Microsoft.EntityFrameworkCore
	//   - Microsoft.EntityFrameworkCore.Sqlite
	//
	// Build & Run:
	//   dotnet add package Microsoft.EntityFrameworkCore
	//   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
	//   dotnet run

	using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;

    namespace EfCoreSetupDemo
    {
        // 1) Entity
        public class Student
        {
            public int Id { get; set; }        // Primary key by convention
            public string Name { get; set; }
            public int Age { get; set; }
        }

        // 2) DbContext
        public class SchoolContext : DbContext
        {
            public DbSet<Student> Students { get; set; }

            // Configure database provider/connection
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // SQLite file for simplicity in a classroom setting
                optionsBuilder.UseSqlite("Data Source=school.db");
            }

            // Optional: basic constraints
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Student>()
                    .Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            }
        }

        // 3) Program
        public class Program
        {
            public static void Main()
            {
                Console.WriteLine("=== EF Core Setup Demo (Solution) ===");

                using var context = new SchoolContext();

                // Ensure database and schema are created (for classroom demos)
                context.Database.EnsureCreated();

                // Seed if empty
                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student { Name = "Alice", Age = 20 },
                        new Student { Name = "Bob", Age = 22 },
                        new Student { Name = "Charlie", Age = 19 }
                    );
                    context.SaveChanges();
                    Console.WriteLine("Database seeded with sample students.");
                }

                // Query
                List<Student> students = context.Students
                                                .OrderBy(s => s.Id)
                                                .ToList();

                Console.WriteLine("\nAll Students in Database:");
                foreach (var s in students)
                {
                    Console.WriteLine($"ID={s.Id}, Name={s.Name}, Age={s.Age}");
                }
            }
        }
    }

}
