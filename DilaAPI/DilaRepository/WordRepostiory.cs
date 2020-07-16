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

        Expression<Func<Word, WordDto>> ToWordDto = w => new WordDto { Id = w.Id, Name = w.Name };

        public async Task<IEnumerable<WordDto>> GetAllAsync()
        {
            var result = await dilaContext.Word.Select(ToWordDto).ToListAsync();
            return result;       
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
        Task<IEnumerable<WordDto>> GetAllAsync();
    }
}
