using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO.Parks;

namespace QuestPlatform.Services.Contracts
{
    public interface IParkService
    {
        Task<ParkDTO> RegisterPark(ParkDTO park);
        Task<IEnumerable<ParkDTO>> GetParks(string managerId);
        Task<ParkDTO> GetPark(Guid parkId);
        Task UpdatePark(ParkDTO park);
        Task DeletePark(Guid parkId);
    }
}
