using AutoMapper;

namespace ProfOaksKantoPokedex.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<Entities.Pokemon, Models.PokemonWithoutMovesLearntDto>();
            CreateMap<Entities.Pokemon, Models.PokemonDto>();
        }
    }
}
