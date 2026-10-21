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
        // 1) Entity // schema of your table
        public class Student
        {
            public int Id { get; set; }        // Primary key by convention
            public string Name { get; set; }
            public int Age { get; set; }

            // update student based on course entity

            public int CourseId { get; set; }   // FK 
            public Course Course { get; set; } 
        }

        // Todo : add course Entity

        public class Course
        {
            // properties become attributes of table
            public int Id { get; set; } // primary key for course
            public string Code { get; set; }
            public string Name { get; set; }
            public int Credits { get; set; }

            /// // Navigation: one-to-many 
            public List<Student> Students { get; set; } = new(); // foreign key will be stored on dependent student row

        }


        // 2) DbContext
        public class SchoolContext : DbContext // interact with database
        {
            public DbSet<Student> Students { get; set; } /// collection of entity instances as table
            public DbSet<Course> Courses {  get; set; }
            // public DbSet<Program> Programs { get; set; } 

            // Configure database provider/connection
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // helps you to configure EFcore
            {
                // SQLite file for simplicity in a classroom setting
                optionsBuilder.UseSqlite("Data Source=school.db");
                
            }

            // Optional: basic constraints // define your rules here.
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

                using var context = new SchoolContext(); // context variable give access of database to your application

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

                // seed value for courses

                if (!context.Courses.Any())
                {
                    var course = new Course { Code = "SDEV", Name = "SMIT", Credits = 3 };
                    course.Students.Add(new Student { Name = "Baljeet", Age=20 });
                    course.Students.Add(new Student { Name = "Alex", Age = 22 });
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
