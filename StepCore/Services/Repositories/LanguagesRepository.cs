using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Entities.Common;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Repositories
{
    public class LanguagesRepository : ILanguagesRepository
    {
        private readonly StepCoreContext _context;
        private readonly ILogger<LanguagesRepository> _logger;

        public LanguagesRepository(StepCoreContext context, ILogger<LanguagesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Languages> Create(Languages languages)
        {
            await _context.Languages.AddAsync(languages);
            await _context.SaveChangesAsync();
            _logger.LogError($"Object Skills created with id {languages.Id}");
            return languages;
        }

        public async Task<List<Languages>> Get()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Languages> Get(int id)
        {
            return await _context.Languages.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            var languages = await this.Get(id);
            if (languages == null)
            {
                _logger.LogError("Could not find activity");
                throw new Exception("Could not find activity");

            }
            else
            {
                _context.Languages.Remove(languages);
                bool success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    _logger.LogError($"Object of type Skills with id {id} was removed");
                    return success;
                }
            }

            throw new Exception("Error saving changes");
        }

        public async Task<bool> Update(int id, Languages languages)
        {
            var originalLanguage = await _context.Languages.FindAsync(id);

            originalLanguage.Name = languages.Name;
            originalLanguage.Status = languages.Status == (int)Enums.Entities.Status.ENABLE ? (int)Enums.Entities.Status.ENABLE : (int)Enums.Entities.Status.DISABLE;
            originalLanguage.UpdatedAt = DateTime.Now;

            var isUpdated = await _context.SaveChangesAsync() > 0;

            if (isUpdated)
            {
                _logger.LogInformation($"The compentency with Id: {id} has been updated");
            }
            else
            {
                _logger.LogError($"Error updating the compentency with Id: {id} ");
            }
            return isUpdated;
        }

    }
}
