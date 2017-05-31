using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Repositories;
using QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Beacons;
using QuestPlatform.Services.Contracts;
using Store.Models;

namespace QuestPlatform.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private IRepository<QuizTask> Quizes;
        private IRepository<Question> Questions;
        private IRepository<BeaconInPark> Beacons;

        public QuizService()
        {
            Quizes = new Repository<QuizTask>();
            Questions = new QuestionRepository();
            Beacons = new BeaconInParkRepository();
        }

        public async Task GenerateQuizzes(Game forGame)
        {
            var beaconsInGame = Beacons.Query(new BeaconsFromPark(forGame.ParkId))
                                       .ToList();
            var questions = (await Questions.Get())
                                       .ToList();


            var usedQuestions = new List<Guid>();
            foreach (var beacon in beaconsInGame)
            {
                // Create questions range for any players
                foreach (var player in forGame.Participants)
                {
                    var randQuestion = GetRandomQuestionFrom(questions, usedQuestions);
                    var quizTask = new QuizTask()
                    {
                        QuizId = player.QuizId,
                        BeaconInParkId = beacon.Id,
                        QuestionId = randQuestion.Id
                    };
                    await Quizes.Insert(quizTask);
                    player.Quiz.QuizTasks.Add(quizTask);
                }
            }
        }
        
        Random random = new Random();
        private Question GetRandomQuestionFrom(List<Question> source, List<Guid> usedQuestions)
        {
            Question randomQuestion;
            do
            {
                randomQuestion = source[random.Next(source.Count)];
            }
            while (usedQuestions.Any(id => id.Equals(randomQuestion.Id)));

            return randomQuestion;
        }
    }
}
