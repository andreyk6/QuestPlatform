using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO.Questions;

namespace QuestPlatform.Services.Contracts
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDTO>> GetAll();
        Task<QuestionDTO> Get(Guid id);

        Task<IQueryable<OptionDTO>> GetQuestionOptions(Guid questionId);
        Task<OptionDTO> GetOption(Guid optionId);

        Task<OptionDTO> GetAnswer(Guid questionId);

        Task RemoveQuestion(Guid id);

        Task RemoveOption(Guid id);
        Task<OptionDTO> UpdateOption(Guid id, OptionDTO option);
        Task<QuestionDTO> CreateQuestion(QuestionDTO question);
        Task<OptionDTO> CreateOption(Guid questionId, OptionDTO option);
    }
}
