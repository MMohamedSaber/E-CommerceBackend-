﻿

namespace E_CommerceBuisnessLayer.Models
{
    public class BestSelling
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product  { get; set; }
        
    }
}
