using DilaRepository;
using DilaShared.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DilaApplication
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await categoryRepository.GetAllAsync();
        }
    }
}
