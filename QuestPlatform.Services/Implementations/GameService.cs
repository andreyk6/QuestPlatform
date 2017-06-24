using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO.Games;
using Models.DTO.Questions;
using Models.DTO.Quizes;
using Models.Requests.Games;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Repositories;
using QuestPlatform.Domain.Infrastructure.Specifications.Concrette.UserInGames;
using QuestPlatform.Services.Contracts;
using QuestPlatform.Services.Exceptions;
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
            game.Date = DateTime.UtcNow;
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
            game.Date = DateTime.Now;
            await Quizes.GenerateQuizzes(game);
            Games.Update(game);
        }

        public async Task<QuizDTO> GetAppUserQuiz(Guid gameId, string userId)
        {
            if(gameId.Equals(new Guid()) || String.IsNullOrEmpty(userId))
                throw new ItemNotFoundException(gameId);
            var quiz = await Quizes.GetQuiz(gameId, userId);
            var quizDTO = new QuizDTO();
            quizDTO.Id = quiz.Id;
            quizDTO.Tasks = Mapper.Map<ICollection<QuizTask>, ICollection<QuizTaskDTO>>(quiz.QuizTasks);
            foreach (var task in quiz.QuizTasks)
            {
                quizDTO.Tasks.FirstOrDefault(t => t.QuestionId.Equals(task.QuestionId)).Options =
                    Mapper.Map<ICollection<Option>, ICollection<OptionDTO>>(task.Question.Options);
            }
            return quizDTO;
        }

        public async Task<ICollection<GameDTO>> SelectUserGames(string userId)
        {
            var players = await Players.Query(new UserWithApplicationUserId(userId))
                                       .ToListAsync();
            var userIdGames = (from player in players
                                select player.Game)
                              .ToList();
            return Mapper.Map<ICollection<Game>, ICollection<GameDTO>>(userIdGames);
        }

        public async Task<Game> GetGame(Guid id)
        {
            return await Games.GetById(id);
        }
        

        public async Task<Quiz> CalculateResult(Quiz input)
        {
            foreach (var task in input.QuizTasks)
            {
                task.Score = task.UserAnswer.Any(o => !o.IsCorrect)
                    ? 0
                    : task.UserAnswer.Count(o => o.IsCorrect) / 
                      task.Question.Options.Count(o => o.IsCorrect);
            }
            input.Score = input.QuizTasks.Sum(t => t.Score) / input.QuizTasks.Count();
            await Quizes.SaveQuizChanges(input);
            return input;
        }
    }
}
