using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Enums;

namespace Store.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        public GameState GameState { get; set; }
        public string TeamName { get; set; }
        //TODO: Add DB trigger "Score = Quizzes.Sum(q=>q.Score)/Quizzes.Count()"
        public int Score { get; set; }

        public DateTime Date { get; set; }

        public Guid BonusId { get; set; }
        [ForeignKey("BonusId")]
        public virtual Bonus Bonus { get; set; }
        
        public Guid ParkId { get; set; }
        [ForeignKey("ParkId")]
        public virtual Park Park { get; set; }

        //List of registered users
        public virtual ICollection<UserInGame> Participants { get; set; }
    }
}
