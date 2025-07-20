using OnlineCourse.Services.Catalog.Dtos;
using OnlineCourse.Services.Catalog.Models;
using OnlineCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineCourse.Services.Catalog.Services
{
    internal interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
