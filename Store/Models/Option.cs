using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Option
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual IQueryable<QuizTask> QuizTasks { get; set; }
    }
}
