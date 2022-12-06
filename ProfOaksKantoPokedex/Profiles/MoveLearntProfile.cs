using AutoMapper;

namespace ProfOaksKantoPokedex.Profiles
{
    public class MoveLearntProfile : Profile
    {
        public MoveLearntProfile()
        {
            CreateMap<Entities.MoveLearnt, Models.MovesLearntDto>();
            CreateMap<Models.MovesLearntForCreationDto, Entities.MoveLearnt>();
            CreateMap<Models.MovesLearntForUpdateDto, Entities.MoveLearnt>();
            CreateMap<Entities.MoveLearnt, Models.MovesLearntForUpdateDto>();   
        }
    }
}
