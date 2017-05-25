using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Models.DTO.Beacons;
using QuestPlatform.Services.Contracts;

namespace QuestPlatform.Api.Controllers
{
    public class BeaconController : ApiController
    {
        private IBeaconsService Service;

        public BeaconController(IBeaconsService service)
        {
            Service = service;
        }

        public async Task<IEnumerable<BeaconDTO>> Get(Guid parkId)
        {
            return await Service.GetParkBeacons(parkId);
        }
    }
}
