using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests.Games
{
    public class NewGameRequest
    {
        public string TeamName { get; set; }
        public Guid ParkId { get; set; }
        public string UserId { get; set; }
    }
}
