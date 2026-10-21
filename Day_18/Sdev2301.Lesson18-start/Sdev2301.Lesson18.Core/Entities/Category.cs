using System;
using System.Collections.Generic;
using System.Text;

namespace Sdev2301.Lesson18.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
