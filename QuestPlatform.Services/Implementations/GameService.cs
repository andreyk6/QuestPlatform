using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.Requests.Games;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Repositories;
using QuestPlatform.Services.Contracts;
using Store.Enums;
using Store.Models;

namespace QuestPlatform.Services.Implementations
{
    public class GameService : IGameService
    {
        private IRepository<Game> Games;
        private IRepository<UserInGame> Players;
        private IQuizService Quizes;
        public GameService(IRepository<Game> games, IRepository<UserInGame> players)
        {
            Games = games;
            Players = players;
        }


        public GameService() : this(new GameRepository(), new UserInGameRepository())
        {
            Quizes = new QuizService();
        }

        public async Task<Game> CreateNewGame(NewGameRequest request)
        {
            var game = Mapper.Map<NewGameRequest, Game>(request);
            return await Games.Insert(game);
        }

        public async Task AddUserToGame(UserInGame user)
        {
            var game = await Games.GetById(user.GameId);
            if (game.Participants.Any(p => p.ApplicationUserId.Equals(user.ApplicationUserId)))
            {
                return;
            }
            await Players.Insert(user);
        }

        public async Task StartGame(Guid gameId)
        {
            var game = await Games.GetById(gameId);
            game.GameState = GameState.Active;
            await Quizes.GenerateQuizzes(game);
            Games.Update(game);
        }

        public async Task<Game> GetGame(Guid id)
        {
            return await Games.GetById(id);
        }
    }
}
