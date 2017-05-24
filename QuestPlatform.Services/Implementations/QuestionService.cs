using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO.Questions;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Questions;
using QuestPlatform.Services.Contracts;
using QuestPlatform.Services.Exceptions;
using Store.Models;

namespace QuestPlatform.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> Questions;
        private readonly IRepository<Option> Options;

        public QuestionService(IRepository<Question> questionRepository,
            IRepository<Option> optionsRepository)
        {
            Questions = questionRepository;
            Options = optionsRepository;
        }

        public async Task<IEnumerable<QuestionDTO>> GetAll()
        {
            var allDomainItems = await Questions.Get();
            var questionDTOs = Mapper.Map<IEnumerable<QuestionDTO>>(allDomainItems);
            return questionDTOs;
        }

        public async Task<QuestionDTO> Get(Guid id)
        {
            var domainQuestion = await Questions.GetById(id);
            return Mapper.Map<QuestionDTO>(domainQuestion);
        }

        public async Task<IQueryable<OptionDTO>> GetQuestionOptions(Guid questionId)
        {
            var domainQuestion = await Questions.GetById(questionId);
            if (domainQuestion == null)
                throw new ItemNotFoundException(questionId);

            return Mapper.Map<IQueryable<OptionDTO>>(domainQuestion.Options);
        }

        public async Task<OptionDTO> GetOption(Guid optionId)
        {
            var domainOption = await Options.GetById(optionId);
            return Mapper.Map<OptionDTO>(domainOption);
        }

        public async Task<OptionDTO> GetAnswer(Guid questionId)
        {
            var correctAnswers = Options.Query(new CorrectAnswerForQuestion(questionId));
            var domainOption = await correctAnswers.FirstOrDefaultAsync();

            if(domainOption == null)
                throw new ItemNotFoundException(questionId);

            return Mapper.Map<OptionDTO>(domainOption);
        }

        public async Task RemoveQuestion(Guid id)
        {
            await Questions.Delete(id);
        }

        public async Task RemoveOption(Guid id)
        {
            await Options.Delete(id);
        }

        public async Task<OptionDTO> UpdateOption(Guid id, OptionDTO option)
        {
            option.Id = id;
            var domainOption = Mapper.Map<Option>(option);
            await Task.Run(() => Options.Update(domainOption));
            return option;
        }

        public async Task<QuestionDTO> CreateQuestion(QuestionDTO question)
        {
            var domainQuestion = Mapper.Map<Question>(question);
            var insertedItem = await Questions.Insert(domainQuestion);
            var domainOptions = question.Options.Select(s => new Option
            {
                QuestionId = insertedItem.Id,
                Content = s.Content,
                IsCorrect = s.IsCorrect
            });
            var insertedOptions = (await Options.InsertRange(domainOptions)).ToList();
            question.Id = insertedItem.Id;
            question.Options = Mapper.Map<ICollection<Option>, 
                ICollection<OptionDTO>>(insertedOptions);
            return question;
        }

        public async Task<OptionDTO> CreateOption(Guid questionId, OptionDTO option)
        {
            var domainOption = Mapper.Map<Option>(option);
            // Bind to question
            domainOption.QuestionId = questionId;

            await Task.Run(() => Options.Update(domainOption));
            return option;
        }
    }
}
