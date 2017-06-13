using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTO.Games;
using Models.DTO.Parks;
using Models.DTO.Questions;
using Models.Requests.Games;
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
                cfg.CreateMap<NewGameRequest, Game>()
                    .ReverseMap();
                cfg.CreateMap<ParkDTO, Park>()
                    .ReverseMap();
                cfg.CreateMap<Game, GameDTO>()
                    .ForMember("GameId", dto => dto.MapFrom(dmn => dmn.Id))
                    .ForMember("TotalScore", dto => dto.MapFrom(dmn => dmn.Score))
                    .ForMember("GameDate", dto => dto.MapFrom(dmn => dmn.Date))
                    .ReverseMap();
            });
        }
    }
}
