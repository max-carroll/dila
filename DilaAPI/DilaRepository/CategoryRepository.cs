using DilaShared.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DilaRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDilaContext context;

        public CategoryRepository(IDilaContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await context.Category.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();


            return categories;
        }
    }
}
