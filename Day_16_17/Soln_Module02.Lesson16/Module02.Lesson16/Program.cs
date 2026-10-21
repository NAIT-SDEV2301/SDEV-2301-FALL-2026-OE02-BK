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
            public string Name { get; set; } = "";
            public int Age { get; set; }

            // update student based on course entity

            public int CourseId { get; set; }   // FK 
            public Course? Course { get; set; } = null!;
        }

        // Todo : add course Entity

        public class Course
        {
            // properties become attributes of table
            public int Id { get; set; } // primary key for course
            public string Code { get; set; } = "";
            public string Name { get; set; } = "";
            public int Credits { get; set; } = 3;

            /// // Navigation: one-to-many 
            public List<Student> Students { get; set; } = new(); // foreign key will be stored on dependent student row

        }


        // 2) DbContext
        public class SchoolContext : DbContext // interact with database
        {
            public DbSet<Student> Students => Set<Student>(); /// collection of entity instances as table
            public DbSet<Course> Courses => Set<Course>();
            // public DbSet<Program> Programs { get; set; } 

            // Configure database provider/connection
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // helps you to configure EFcore
            {
                // SQLite file for simplicity in a classroom setting
                optionsBuilder.UseSqlite("Data Source=school_student_course.db");
                
            }

            // Optional: basic constraints // define your rules here.
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Course>(b =>
                {
                    b.Property(c => c.Code).IsRequired().HasMaxLength(20);
                    b.Property(c => c.Name).IsRequired().HasMaxLength(100);
                    b.HasMany(c => c.Students)
                     .WithOne(s => s.Course!)
                     .HasForeignKey(s => s.CourseId)
                     .OnDelete(DeleteBehavior.Cascade);
                });
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
                Console.WriteLine("=== EF Core CRUD operations ===");

                using var context = new SchoolContext(); // context variable give access of database to your application

                // Ensure database and schema are created (for classroom demos)
                //context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                // 1) CREATE -------------------------------------------------------
                var course = new Course { Code = "SDEV2301", Name = "Enterprise App Dev", Credits = 3 };
                context.Courses.Add(course);
                var course1 = new Course
                {
                    Code = "SDEV2200",
                    Name = "Backend ",
                    Credits = 5
                };

                context.Students.AddRange(
                    new Student { Name = "Alice", Age = 20, Course = course },
                    new Student { Name = "Bob", Age = 22, Course = course },
                    new Student { Name = "Cara", Age = 19, Course = course },
                    new Student { Name = "Baljeet", Age = 20, Course = course1 }
                );

                context.SaveChanges();
                Console.WriteLine("Created course + 3 students.");


                // Query
                List<Student> students = context.Students
                                                .OrderBy(s => s.Id)
                                                .ToList();

                Console.WriteLine("\nAll Students in Database:");
                foreach (var s in students)
                {
                    Console.WriteLine($"student ID={s.Id}, S Name={s.Name}, Age={s.Age}, course ={s.Course.Code}");
                }

                // query course 
                List<Course> courses = context.Courses
                                                .OrderBy(s => s.Id)
                                                .ToList();

                Console.WriteLine("\nAll Courses in Database:");
                foreach (var c in courses)
                {
                    Console.WriteLine($"course ID={c.Id}, C Name={c.Name}, credit = {c.Credits}");
                }


                // 2) READ (with relationship) ------------------------------------
                var loadedCourse = context.Courses
                    .Include(c => c.Students)
                    .Single(c => c.Code == "SDEV2301");

                Console.WriteLine($"\nREAD: {loadedCourse.Code} - {loadedCourse.Name} ({loadedCourse.Credits} credits)");
                foreach (var s in loadedCourse.Students)
                    Console.WriteLine($" - Student #{s.Id}: {s.Name} (Age {s.Age})");

                // 3) UPDATE (entity + child) -------------------------------------
                loadedCourse.Credits = 4; // update parent
                var bob = loadedCourse.Students.Single(s => s.Name == "Bob");
                bob.Age = 23;             // update child
                context.SaveChanges();
                Console.WriteLine("\nUPDATE: Course credits -> 4; Bob's age -> 23");

                // Show updated state
                var check = context.Courses.Include(c => c.Students).Single(c => c.Id == loadedCourse.Id);
                //Console.WriteLine($"Confirm: {check.Code} now {check.Credits} credits; Bob age = {check.Students.Single(s => s.Name == \"Bob\").Age}");
                Console.WriteLine($"Confirm: {check.Code} now {check.Credits} credits;");
                // 4) DELETE (child or parent) ------------------------------------
                // Delete one student
                var cara = check.Students.Single(s => s.Name == "Cara");
                context.Students.Remove(cara);
                context.SaveChanges();
                Console.WriteLine("\nDELETE: Removed Cara.");

                // Delete the course (cascade deletes remaining students)
                context.Courses.Remove(check);
                context.SaveChanges();
                Console.WriteLine("DELETE: Removed course (cascade deleted remaining students).");

                // 5) Verify empty -------------------------------------------------
                Console.WriteLine($"\nCounts -> Courses: {context.Courses.Count()}, Students: {context.Students.Count()}");
                Console.WriteLine("\nDemo complete.");

            }
        }
    }

}
