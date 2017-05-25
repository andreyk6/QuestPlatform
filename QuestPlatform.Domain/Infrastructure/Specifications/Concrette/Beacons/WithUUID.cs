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
    public class WithUUID : ISpecification<BeaconInPark>
    {
        private string Uuid;

        public WithUUID(string uuid)
        {
            Uuid = uuid;
        }

        public Expression<Func<BeaconInPark, bool>> IsSatisifiedBy()
        {
            return b => b.Beacon.UUID.Equals(Uuid);
        }
    }
}
