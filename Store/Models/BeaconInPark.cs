using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class BeaconInPark
    {
        public Guid Id { get; set; }

        public Guid ParkId { get; set; }
        public virtual Park Park { get; set; }

        public Guid BeaconId { get; set; }
        public virtual Beacon Beacon { get; set; }

        //TODO: Or replace with NextBeaconId and PrevBeaconId?
        public int SequenceNumber { get; set; }

        public string NextBeaconLocationTip { get; set; }
    }
}
