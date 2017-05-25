using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Beacons
{
    public class BeaconsFromPark : ISpecification<BeaconInPark>
    {
        private Guid ParkId { get; set; }

        public BeaconsFromPark(Guid parkId)
        {
            ParkId = parkId;
        }

        public Expression<Func<BeaconInPark, bool>> IsSatisifiedBy()
        {
            return b => b.ParkId.Equals(ParkId);
        }
    }
}
