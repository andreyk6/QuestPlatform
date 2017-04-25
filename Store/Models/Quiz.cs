using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }

        //TODO: Add DB trigger "Score = QuizTasks.Sum(t=>t.Score)/QuizTasks.Count()"
        public int Score { get; set; }

        public virtual IQueryable<QuizTask> QuizTasks { get; set; }
    }
}
