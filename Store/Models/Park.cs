using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Park
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string ImageUrl { get; set; }
        
        public string ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual ApplicationUser Manager { get; set; }

        public virtual ICollection<BeaconInPark> Beacons { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
