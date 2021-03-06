﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO.Beacons;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Beacons;
using QuestPlatform.Services.Contracts;
using Store.Models;

namespace QuestPlatform.Services.Implementations
{
    public class BeaconsService : IBeaconsService
    {
        private IRepository<BeaconInPark> BeaconsInPark;

        public BeaconsService(IRepository<BeaconInPark> beaconsInPark)
        {
            BeaconsInPark = beaconsInPark;
        }
        
        public async Task<ICollection<BeaconDTO>> GetParkBeacons(Guid parkId)
        {
            var beaconsInPark = await BeaconsInPark.Query(new BeaconsFromPark(parkId)).ToListAsync();
            var dto = Mapper.Map<ICollection<BeaconInPark>, ICollection<BeaconDTO>>(beaconsInPark);
            return dto;
        }  

        public async Task<BeaconDTO> RegisterBeacon(BeaconDTO beacon)
        {
            var newParkBeacon = Mapper.Map<BeaconDTO, BeaconInPark>(beacon);
            var registerResultBeacon = await BeaconsInPark.Insert(newParkBeacon);
            beacon.Id = registerResultBeacon.Id;
            return beacon;
        }

        public async Task DeleteBeaconFromPark(Guid parkId, string UUID)
        {
            await DeleteBeaconFormPark(parkId, BeaconsInPark.Query(new WithUUID(UUID))
                                                            .FirstOrDefault()
                                                            .Id);
        }

        public async Task DeleteBeaconFormPark(Guid parkId, Guid beaconId)
        {
            await BeaconsInPark.Delete(beaconId);
        }
    }
}
