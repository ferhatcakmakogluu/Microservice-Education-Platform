using OnlineCourse.Services.Catalog.Dtos;
using OnlineCourse.Services.Catalog.Models;
using OnlineCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
