using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Bonus
    {
        public Guid Id { get; set; }

        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
