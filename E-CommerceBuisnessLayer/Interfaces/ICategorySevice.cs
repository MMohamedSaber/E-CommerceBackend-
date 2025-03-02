using E_CommerceBuisnessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
    }
}
