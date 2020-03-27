using AutoMapper;

namespace _17_automapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(gamevm => gamevm.PubId,
                    opt => opt.MapFrom(game => game.Publisher.Id))
                .ForMember(gamevm => gamevm.PubName,
                    opt => opt.MapFrom(game => game.Publisher.Name))
                .ForMember(gamevm => gamevm.FullDesc,
                    opt => opt.MapFrom(game => $"{game.Title} ({game.Publisher.Name})"));
            CreateMap<GameViewModel, Game>()
                .ForMember(game => game.Publisher,
                    opt => opt.MapFrom(gamevm => new Publisher {Id = gamevm.PubId, Name = gamevm.PubName}));
        }
    }
}

