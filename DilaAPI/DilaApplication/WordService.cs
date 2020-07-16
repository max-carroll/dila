using DilaRepository;
using DilaShared.Dto;
using Entities;
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

        public async Task<WordDto> InsertAsync(WordDto dto)
        {
            var word = new Word { Name = dto.Name };

            var result = await wordRespository.InsertAsync(word);
            return result;

        }
    }

    public interface IWordService
    {
        Task<WordDto> InsertAsync(WordDto dto);
        Task<IEnumerable<WordDto>> GetAllAsync();
    }
}
