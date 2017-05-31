using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //TODO: Add DB trigger "Score = QuizTasks.Sum(t=>t.Score)/QuizTasks.Count()"
        public int Score { get; set; }

        public virtual ICollection<QuizTask> QuizTasks { get; set; }
    }
}
