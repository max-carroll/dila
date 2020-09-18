using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DilaApplication;
using DilaShared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DilaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var words = await categoryService.GetAllAsync();
            return words;
        }

    }
}
