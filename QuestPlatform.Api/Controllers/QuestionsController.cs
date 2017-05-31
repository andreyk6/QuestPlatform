using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using Models.DTO.Questions;
using QuestPlatform.Domain.Infrastructure.Repositories;
using QuestPlatform.Services.Contracts;
using QuestPlatform.Services.Exceptions;
using QuestPlatform.Services.Implementations;
using Store.Models;

namespace QuestPlatform.Api.Controllers
{
    //[Authorize]
    public class QuestionsController : ApiController
    {
        private IQuestionService QuestionManager;

        public QuestionsController():this(new QuestionService(new QuestionRepository(), new Repository<Option>()))
        {
            
        }

        public QuestionsController(IQuestionService questionService)
        {
            QuestionManager = questionService;
        }

        [Route("api/questions/")]
        [HttpGet]
        public async Task<IEnumerable<QuestionDTO>> Get()
        {
            return await QuestionManager.GetAll();
        }

        [Route("api/questions/{id}")]
        [HttpGet]
        public async Task<QuestionDTO> Get(Guid id)
        {
            return await QuestionManager.Get(id);
        }

        [Route("api/questions/{id}/options")]
        public async Task<IEnumerable<OptionDTO>> GetOptions(Guid id)
        {
            return await QuestionManager.GetQuestionOptions(id);
        }

        [Route("api/questions/{id}/options/{optionId}")]
        [HttpGet]
        public async Task<OptionDTO> GetOptions(Guid id, Guid optionId)
        {
            return await QuestionManager.GetOption(optionId);
        }

        [Route("api/questions/")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]QuestionDTO question)
          {
            try
            {
                var createdItem = await QuestionManager.CreateQuestion(question);
                return Ok(createdItem);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        
        [Route("api/options/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(Guid id, [FromBody]OptionDTO option)
        {
            try
            {
                var updatedState = await QuestionManager.UpdateOption(id, option);
                return Ok(updatedState);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("api/questions/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            try
            {
                await QuestionManager.RemoveQuestion(id);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("api/questions/{id}/options/{optionId}")]
        [HttpDelete]
        public async  Task<IHttpActionResult> DeleteOption(Guid id, Guid optionId)
        {
            try
            {
                await QuestionManager.RemoveOption(optionId);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
