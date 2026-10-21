using Microsoft.EntityFrameworkCore;
using Sdev2301.Lesson18.Core.Data;
using Sdev2301.Lesson18.Core.Entities;
using Sdev2301.Lesson18.Core.Services;

// Demo-only schema creation, suitable for a disposable classroom SQLite file.
// Use EF Core migrations when preserving/evolving important real data.
var dbPath = Path.GetFullPath(Path.Combine(
    AppContext.BaseDirectory, "..", "..", "..", "lesson18.db"));
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={dbPath}")
    .Options;

using var context = new AppDbContext(options);
context.Database.EnsureCreated();

if (!context.Categories.Any())
{
    context.Categories.Add(new Category { Name = "Electronics" });
    context.SaveChanges();
}

var category = context.Categories.Single(c => c.Name == "Electronics");

// Starter seed: temporary infrastructure, not a business-service example.
if (!context.Products.Any())
{
    context.Products.AddRange(
        new Product
        {
            Sku = "MOU-001",
            Name = "Mouse",
            Price = 24.99m,
            CategoryId = category.Id,
            IsActive = true
        },
        new Product
        {
            Sku = "KEY-001",
            Name = "Keyboard",
            Price = 49.99m,
            CategoryId = category.Id,
            IsActive = true
        },
        new Product
        {
            Sku = "OLD-001",
            Name = "Old Keyboard",
            Price = 15m,
            CategoryId = category.Id,
            IsActive = false
        });
    context.SaveChanges();
}

var service = new ProductService(context);
Console.WriteLine("Active products from ProductService:");
foreach (var product in service.GetActiveProducts())
    Console.WriteLine($"{product.Sku}: {product.Name}");

// Slide 19 — tuple exercise (complete during class AFTER GetActiveProducts works).
// Review this completed named-tuple example from Slide 18:
var example = (Name: "Mouse", Price: 24.99m);
Console.WriteLine($"Example tuple: {example.Name} costs {example.Price:C}");

// TODO 5A: Get the first active Product using service.GetActiveProducts().First().
// TODO 5B: Make a NEW named tuple containing its Name and Price.
// TODO 5C: Print the tuple's named elements using dot notation.
// TODO 5D: Deconstruct that tuple into two local variables and print them.
// Expected syntax for deconstruction: var (name, price) = info;
// Compare with instructor reference AFTER attempting Slide 19.

// After implementing CreateProduct, uncomment this optional demonstration:
// if (!context.Products.Any(p => p.Sku == "USB-001"))
//     service.CreateProduct("USB-001", "USB Cable", 12.99m, category.Id);

Console.WriteLine($"Database: {dbPath}");
