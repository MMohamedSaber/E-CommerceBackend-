using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        // Navigation Properties
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        // Navigation Properties
        public int BrandId { get; set; }
        public BrandDTO Brand { get; set; }
    }
}
