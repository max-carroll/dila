using DilaShared.Dto;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DilaRepository
{

    public class WordRepository : IWordRepository
    {
        private readonly IDilaContext dilaContext;

        public WordRepository(IDilaContext dilaContext)
        {
            this.dilaContext = dilaContext;
        }

        Expression<Func<Word, WordDto>> ToWordDto = w => 
        new WordDto { 
            Id = w.Id, 
            Name = w.Name,
            Emoji = w.Emoji,
            Language = w.Language,
            Translation = w.Translation,
            Type = w.Type,
            Categories = w.WordCategories.Select(wc => new CategoryDto
            {
                Id = wc.CategoryId,
                Name = wc.Category.Name
            })
        };

        public async Task<IEnumerable<WordDto>> GetAllAsync()
        {
            var result = await dilaContext.Word.Select(ToWordDto).ToListAsync();
            return result;
        }

        public async Task InsertCategoriesAsync(IEnumerable<Category> categories)
        {
            dilaContext.Category.AddRange(categories);

            await dilaContext.SaveChangesAsync();
        }

        public async Task<WordDto> InsertAsync(Word word)
        {
            dilaContext.Word.Add(word);

            await dilaContext.SaveChangesAsync();

            var dto = ToWordDto.Compile()(word);
            return dto;
        }
    }

    public interface IWordRepository
    {
        Task<WordDto> InsertAsync(Word word);

        Task InsertCategoriesAsync(IEnumerable<Category> categories);
        Task<IEnumerable<WordDto>> GetAllAsync();
    }
}
