using DilaRepository;
using DilaShared.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var existingCategories = dto.Categories.Where(c => c.Id != 0);

            var newCategories = dto.Categories.Where(c => c.Id == 0).Select(c => new Category { Name = c.Name }).ToList();

            await wordRespository.InsertCategoriesAsync(newCategories);


            var wordCategories = new List<WordCategory>(existingCategories.Select(c=> new WordCategory {CategoryId =  c.Id}));

            wordCategories.AddRange(newCategories.Select(c => new WordCategory { CategoryId = c.Id }));

            var word = new Word { 
                Name = dto.Name,
                Emoji = dto.Emoji,
                Language = dto.Language,
                Translation = dto.Translation,
                Type = dto.Type,
                // TODO, we want these to be unique 
                WordCategories = wordCategories
           
            };

            foreach (var category in word.WordCategories) category.Word = word;

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
