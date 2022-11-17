using SuperShop.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace SuperShop.Business.Suggestions.Services
{
    public class SuggestionsService
    {
        private readonly FakeDexContext _fakeDexContext;

        public SuggestionsService(FakeDexContext fakeDexContext)
        {
            _fakeDexContext = fakeDexContext;
        }

        public async Task<long> AddSuggestions(SuggestionsRequestDto suggestionsRequestDto)
        {
            var suggestion = new Models.Data.Suggestion
            {
                Email = suggestionsRequestDto.Email,
                Asunto = suggestionsRequestDto.Asunto,
                Descripcion = suggestionsRequestDto.Descripcion

            };
            await _fakeDexContext.Suggestion.AddAsync(suggestion);
            await _fakeDexContext.SaveChangesAsync();
            return suggestion.Id;
        }


        public async Task<List<Models.Data.Suggestion>> GetSuggestions()
        {
            return await _fakeDexContext.Suggestion.ToListAsync();
        }
    }
}