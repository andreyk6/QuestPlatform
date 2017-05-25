using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.Parks
{
    public class ParkDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        // TODO: REPLACE WITH FILE UPLOAD TYPE
        public string ImageUrl { get; set; }

        public string ManagerId { get; set; }
    }
}
