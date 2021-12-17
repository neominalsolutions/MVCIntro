using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntro.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }

    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
        public int TotalCount { get; set; }
        public ProductInputModel Input { get; set; }
        public string DeleteId { get; set; }


    }
}
