using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Questions
{
    public class OptionDTO
    {
        public OptionDTO()
        {
        }

        public OptionDTO(string content, bool isCorrect = false)
        {
            Content = content;
            IsCorrect = isCorrect;
        }
        
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}
