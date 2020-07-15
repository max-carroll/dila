using DilaRepository;
using DilaShared.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DilaApplication
{
    public class WordService : IWordService
    {
        private readonly IWordRepository wordRespository;

        public WordService(IWordRepository wordRespository)
        {
            this.wordRespository = wordRespository;
        }

        public async Task<IEnumerable<WordDto>> GetAllAsync()
        {
            return await wordRespository.GetAllAsync();
        }        
    }

    public interface IWordService
    {
        Task<IEnumerable<WordDto>> GetAllAsync();
    }
}
