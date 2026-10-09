using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13_LinqIntro
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Category { get; }
        public Product(
        string name,
        decimal price,
        string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
