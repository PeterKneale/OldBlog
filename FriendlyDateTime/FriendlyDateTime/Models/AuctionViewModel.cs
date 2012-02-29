using AutoMapper;
using FriendlyDateTime.Code.Domain;
using FriendlyDateTime.Code.Extensions;

namespace FriendlyDateTime.Models
{
    public class AuctionViewModel
    {
        public string Name { get; set; }
        public string FriendlyCreatedAt { get; set; }
        public string FriendlyStartedAt { get; set; }
        public string FriendlyEndedAt { get; set; }
    }

    public class AuctionViewModelMappings
    {
        public static void Setup()
        {
            Mapper.CreateMap<Auction, AuctionViewModel>()
                .ForMember(
                            dst => dst.FriendlyCreatedAt, 
                            opt => opt.MapFrom(src => src.CreatedAt.ToFriendlyString()))
                .ForMember(
                            dst => dst.FriendlyStartedAt, 
                            opt => opt.MapFrom(src => src.StartedAt.ToFriendlyString()))
                .ForMember(
                            dst => dst.FriendlyEndedAt,
                            opt => opt.MapFrom(src => src.EndedAt.ToFriendlyString()));
        }
    }
}