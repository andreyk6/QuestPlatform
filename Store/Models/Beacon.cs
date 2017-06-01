using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Beacon
    {
        [Key, ForeignKey("BeaconInPark")]
        public Guid Id { get; set; }
        public string UUID { get; set; }
        public string TresholdRSSI { get; set; }

        public Guid BeaconInParkId { get; set; }
        [ForeignKey("BeaconInParkId")]
        public virtual BeaconInPark BeaconInPark { get; set; }
    }
}
