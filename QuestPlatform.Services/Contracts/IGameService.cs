using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO.Games;
using Models.Requests.Games;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Services.Contracts
{
    public interface IGameService
    {
        Task<Game> CreateNewGame(NewGameRequest request);
        Task AddUserToGame(UserInGame user);
        Task StartGame(Guid gameId);
        Task<Game> GetGame(Guid id);
        Task<Quiz> CalculateResult(Quiz quiz);
        Task<ICollection<GameDTO>> SelectUserGames(string userId);
    }
}
