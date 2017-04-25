using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Beacon
    {
        public Guid Id { get; set; }
        public string UUID { get; set; }

        public Guid BeaconInParkId { get; set; }
        public virtual BeaconInPark BeaconInPark { get; set; }
    }
}
