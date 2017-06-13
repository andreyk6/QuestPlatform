using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace QuestPlatform.Services.Contracts
{
    public interface IQuizService
    {
        Task GenerateQuizzes(Game forGame);
        Task<Quiz> GetQuiz(Guid gameId, string appUserId);
        Task SaveQuizChanges(Quiz toSave);
    }
}
