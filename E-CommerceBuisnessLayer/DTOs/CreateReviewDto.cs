using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.DTOs
{
    public class CreateReviewDto
    {
        public string Review { get; set; }
        public int Stars { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
