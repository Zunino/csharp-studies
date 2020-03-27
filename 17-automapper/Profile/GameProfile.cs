using AutoMapper;

namespace _17_automapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(gamevm => gamevm.PubName,
                    opt => opt.MapFrom(game => game.Publisher.Name));
        }
    }
}

