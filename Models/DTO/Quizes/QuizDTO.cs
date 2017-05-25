using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Quizes
{
    public class QuizDTO
    {
        public Guid Id { get; set; }
        public ICollection<QuizTaskDTO> Tasks { get; set; }
    }
}
