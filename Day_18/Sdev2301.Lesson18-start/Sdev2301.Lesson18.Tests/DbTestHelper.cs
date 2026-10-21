using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Sdev2301.Lesson18.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sdev2301.Lesson18.Tests
{
    public static class DbTestHelper
    {
        // A named C# tuple returns two resources from one method.
        public static (AppDbContext Context, SqliteConnection Connection) Create()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open(); // in-memory SQLite database lasts while open
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .Options;
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return (context, connection);
        }
    }
}
