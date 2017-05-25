using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class StartNewGameRequest
    {
        public string TeamName { get; set; }
        public Guid ParkId { get; set; }
        public Guid? BonusId { get; set; }
    }
}
