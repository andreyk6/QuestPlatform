using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Questions
{
    public class CorrectAnswerForQuestion: ISpecification<Option>
    {
        private readonly Guid QuestionId;

        public CorrectAnswerForQuestion(Guid questionId)
        {
            QuestionId = questionId;
        }

        public Expression<Func<Option, bool>> IsSatisifiedBy()
        {
            return opt => opt.QuestionId.Equals(QuestionId) && opt.IsCorrect;
        }
    }
}
