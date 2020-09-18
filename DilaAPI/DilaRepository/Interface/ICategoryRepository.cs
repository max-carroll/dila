using DilaShared.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DilaRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
    }
}