using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class UserInGame
    {
        public Guid Id { get; set; }

        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
