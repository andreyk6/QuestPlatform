using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class QuizTask
    {
        public Guid Id { get; set; }

        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public Guid BeaconInParkId { get; set; }
        public virtual BeaconInPark BeaconInPark { get; set; }

        //TODO: Add DB trigger
        /// <summary>
        /// If UserAnswer.Any(o=>o.IsCorrect = false) then Score = 0
        /// Else Score = UserAnswer.Count(o=>o.IsCorrect)/Question.Options.Count(o=>o.IsCorrect)
        /// </summary>
        public int Score { get; set; }

        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }

        /// <summary>
        /// Selected options from Question.Options
        /// </summary>
        public virtual IQueryable<Option> UserAnswer { get; set; }
    }
}
