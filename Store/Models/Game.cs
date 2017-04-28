using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Enums;

namespace Store.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public GameState GameState { get; set; }
        public string TeamName { get; set; }
        //TODO: Add DB trigger "Score = Quizzes.Sum(q=>q.Score)/Quizzes.Count()"
        public int Score { get; set; }

        public Guid BonusId { get; set; }
        public virtual Bonus Bonus { get; set; }


        public Guid ParkId { get; set; }
        public virtual Park Park { get; set; }

        //List of registered users
        public virtual IQueryable<UserInGame> Participants { get; set; }
    }
}
