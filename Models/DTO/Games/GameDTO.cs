using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Enums;

namespace Models.DTO.Games
{
    public class GameDTO
    {
        public Guid GameId { get; set; }
        public int TotalScore { get; set; }
        public DateTime GameDate { get; set; }
        public GameState GameState { get; set; }
        public string TeamName { get; set; }
    }
}
