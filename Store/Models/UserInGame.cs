using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class UserInGame
    {
        [Key, ForeignKey("UserAccount")]
        public string Id { get; set; }

        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser UserAccount { get; set; }
    }
}
