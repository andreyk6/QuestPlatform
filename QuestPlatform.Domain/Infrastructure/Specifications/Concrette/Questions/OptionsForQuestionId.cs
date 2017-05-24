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
    public class OptionsForQuestionId: ISpecification<Option>
    {
        private Guid questionId;

        public OptionsForQuestionId(Guid questionId)
        {
            this.questionId = questionId;
        }

        public Expression<Func<Option, bool>> IsSatisifiedBy()
        {
            return opt => opt.QuestionId.Equals(questionId);
        }
    }
}
