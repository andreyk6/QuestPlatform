using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO.Beacons;
using Store.Models;

namespace QuestPlatform.Services.Contracts
{
    public interface IBeaconsService
    {
        Task<ICollection<BeaconDTO>> GetParkBeacons(Guid parkId);
        Task<BeaconDTO> RegisterBeacon(BeaconDTO beacon);
        Task DeleteBeaconFromPark(Guid parkId, string UUID);
        Task DeleteBeaconFormPark(Guid parkId, Guid beaconId);
    }
}
