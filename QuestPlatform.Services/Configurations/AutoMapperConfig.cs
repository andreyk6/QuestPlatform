using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO.Questions;
using Store.Models;

namespace QuestPlatform.Services.Configurations
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<QuestionDTO, Question>()
                    .ForMember(dto => dto.Options, dmn => dmn.Ignore())
                    .ReverseMap();
                cfg.CreateMap<OptionDTO, Option>()
                    .ReverseMap();
            });
        }
    }
}
