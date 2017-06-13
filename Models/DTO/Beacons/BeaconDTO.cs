using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Beacons
{
    public class BeaconDTO
    {
        public Guid Id { get; set; }
        public string UUID { get; set; }

        public int TresholdRSSI { get; set; }
        public string LocationTip { get; set; }

        public Guid ParkId { get; set; }
        public int SequenceNumber { get; set; }
    }
}
