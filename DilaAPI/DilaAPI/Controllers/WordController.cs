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
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
       

        private readonly ILogger<WordController> _logger;
        private readonly IWordService wordService;

        public WordController(ILogger<WordController> logger, IWordService wordService)
        {
            _logger = logger;
            this.wordService = wordService;
        }

        [HttpGet]
        public async Task<IEnumerable<WordDto>> GetAllAsync()
        {
            var words = await wordService.GetAllAsync();
            return words;
                
        }
    }
}
