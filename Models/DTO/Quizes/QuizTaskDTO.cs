using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO.Beacons;
using Models.DTO.Questions;

namespace Models.DTO.Quizes
{
    public class QuizTaskDTO
    {
        public Guid Id { get; set; }
        public Guid BeaconInParkId { get; set; }
        public string NextLocationTip { get; set; }

        public Guid QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public ICollection<OptionDTO> Options { get; set; }
        public Guid Answer { get; set; }

        public int Score
        {
            get
            {
                var correctAnswersCount 
                    = Options.Count(o => o.IsCorrect);
                if (correctAnswersCount > 1)
                {
                    // TODO: MULTIPLE ANSWERS
                }

                if (Options.Any(op => op.Id.Equals(Answer) && op.IsCorrect))
                {
                    return 100;
                }
                return 0;
            }
        }
    }
}
