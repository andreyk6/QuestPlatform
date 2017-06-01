using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models.Requests.Games;
using QuestPlatform.Services.Contracts;
using QuestPlatform.Services.Implementations;
using Store.Enums;
using Store.Models;

namespace QuestPlatform.Api.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        private IGameService games;

        public GameController(IGameService gameService)
        {
            games = gameService;
        }

        public GameController():this(new GameService())
        {
            
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(NewGameRequest game)
        {
            game.UserId = HttpContext.Current.User.Identity.GetUserId();
            var domainGame= await games.CreateNewGame(game);
            return Ok(domainGame);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Join(Guid? id)
        {
            var user = new UserInGame()
            {
                ApplicationUserId = HttpContext.Current.User.Identity.GetUserId(),
                GameId = id.Value,
                Quiz = new Quiz()
            };
            await games.AddUserToGame(user);
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Start(Guid? id)
        {
            try
            {
                await games.StartGame(id.Value);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("/Game/{gameId}/GetQuest")]
        public async Task<IHttpActionResult> GetQuest(Guid? gameId)
        {
            var game = await games.GetGame(gameId.Value);
            if (!game.GameState.Equals(GameState.Active))
            {
                return BadRequest("Game is not started");
            }
            var player = game.Participants.FirstOrDefault(p => p.ApplicationUserId
                .Equals(HttpContext.Current.User.Identity.GetUserId()));

            if (player == null) return InternalServerError();
            return Ok(player.Quiz);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CalculateResult(Quiz quiz)
        {
            try
            {
                var calculatedQuiz = await games.CalculateResult(quiz);
                return Ok(calculatedQuiz);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
