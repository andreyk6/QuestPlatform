using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Facebook;
using Models.DTO.Parks;
using QuestPlatform.Domain.Infrastructure.Repositories;
using QuestPlatform.Services.Contracts;
using QuestPlatform.Services.Implementations;

namespace QuestPlatform.Api.Controllers
{
    [Authorize]
    public class ParkController : ApiController
    {
        private string ApplicationUserId
        {
            get { return RequestContext.Principal.Identity.GetUserId(); }
        }

        private IParkService ParkService;

        public ParkController(IParkService parkService)
        {
            ParkService = parkService;
        }

        public ParkController():this(new ParkService(new ParkRepository()))
        {
            
        }

        [HttpGet]
        public async Task<ParkDTO> Get(Guid id)
        {
            return await ParkService.GetPark(id);
        }

        [HttpPost]
        public async Task<ParkDTO> Post(ParkDTO model)
        {
            // Bind manager to park
            model.ManagerId = ApplicationUserId;
            return await ParkService.RegisterPark(model);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(ParkDTO newModel)
        {
            await ParkService.UpdatePark(newModel);
            return Ok(newModel);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            await ParkService.DeletePark(id);
            return Ok(new {success= true, message="deleted"});
        }
    }
}
