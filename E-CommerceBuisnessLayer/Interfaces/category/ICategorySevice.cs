using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Interfaces.category
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDTO>> GetAllAsync();
    }
}
