using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class QuizTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        public Guid BeaconInParkId { get; set; }
        [ForeignKey("BeaconInParkId")]
        public virtual BeaconInPark BeaconInPark { get; set; }

        //TODO: Add DB trigger
        /// <summary>
        /// If UserAnswer.Any(o=>o.IsCorrect = false) then Score = 0
        /// Else Score = UserAnswer.Count(o=>o.IsCorrect)/Question.Options.Count(o=>o.IsCorrect)
        /// </summary>
        public int Score { get; set; }

        public Guid QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        /// <summary>
        /// Selected options from Question.Options
        /// </summary>
        public virtual ICollection<Option> UserAnswer { get; set; }
    }
}
