using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Repositories
{
    public class QuestionRepository : Repository<Question>
    {
        public override async Task<Question> GetById(Guid id)
        {
            var question = await Context.Questions
                                            .Where(q => q.Id.Equals(id))
                                            .Include("Options.Question")
                                            .FirstOrDefaultAsync();
            return question;
        }

        public override async Task<IEnumerable<Question>> Get()
        {
            return await Context.Questions.Include("Options.Question").ToListAsync();
        }
    }
}
