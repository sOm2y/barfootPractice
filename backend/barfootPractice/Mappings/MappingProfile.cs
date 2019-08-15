using AutoMapper;
using barfootPractice.Models;
using barfootPractice.Models.Dtos;

namespace barfootPractice.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Listing, ListingViewDto>();
            CreateMap<ListingViewDto, Listing>();

            CreateMap<Listing, ListingConfidentialViewDto>();
            CreateMap<ListingConfidentialViewDto, Listing>();

            CreateMap<ListingUpdateDto, Listing>()
                .ForMember(dest => dest.ConfidentialNote, act => act.Condition(src => (src.ConfidentialNote != null)));
            CreateMap<Listing, ListingUpdateDto> ()
                .ForMember(dest => dest.ConfidentialNote, act => act.Condition(src => (src.ConfidentialNote != null)));
        }
     
    }
}
