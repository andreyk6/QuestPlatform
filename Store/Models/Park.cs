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
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string ImageUrl { get; set; }


        public virtual Guid ManagerId { get; set; }
        public virtual ApplicationUser Manager { get; set; }

        public virtual IQueryable<BeaconInPark> Beacons { get; set; }
        public virtual IQueryable<Game> Games { get; set; }
    }
}
