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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser UserAccount { get; set; }
    }
}
