using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserInGameId { get; set; }
        public virtual UserInGame UserInGame { get; set; }

        public Guid BonusId { get; set; }
        public virtual Bonus Bonus { get; set; }

        public double Price { get; set; }
        public double Payed { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
