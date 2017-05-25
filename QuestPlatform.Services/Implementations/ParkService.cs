using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO.Parks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Parks;
using QuestPlatform.Services.Contracts;
using Store.Models;

namespace QuestPlatform.Services.Implementations
{
    public class ParkService : IParkService
    {
        private IRepository<Park> Parks;

        public ParkService(IRepository<Park> parks)
        {
            Parks = parks;
        }

        public async Task<ParkDTO> RegisterPark(ParkDTO park)
        {
            var domainPark = Mapper.Map<ParkDTO, Park>(park);
            var registerResult = await Parks.Insert(domainPark);
            park.Id = registerResult.Id;

            return park;
        }

        public async Task<IEnumerable<ParkDTO>> GetParks(string managerId)
        {
            var domainParks = await Parks.Query(new ManagerParks(managerId))
                .ToListAsync();
            var dtos = Mapper.Map<ICollection<Park>,
                ICollection<ParkDTO>>(domainParks);
            return dtos;
        }

        public async Task<ParkDTO> GetPark(Guid parkId)
        {
            var park = await Parks.GetById(parkId);
            return Mapper.Map<Park, ParkDTO>(park);
        }

        public async Task UpdatePark(ParkDTO park)
        {
            var updatedId = park.Id;
            var domainPark = Mapper.Map<ParkDTO, Park>(park);
            Parks.Update(domainPark);
        }

        public async Task DeletePark(Guid parkId)
        {
            await Parks.Delete(parkId);
        }
    }
}
