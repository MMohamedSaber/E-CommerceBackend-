using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_CommerceBuisnessLayer.Interfaces.review
{
    public interface IReviewService
    {
        Task<ReviewDetails> AddNew(CreateReviewDto review);
        Task<ReviewDetails> Update(int Id, CreateReviewDto review);
        Task Delete(int Id);
    }
}
