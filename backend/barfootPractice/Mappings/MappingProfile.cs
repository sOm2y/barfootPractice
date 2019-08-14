using AutoMapper;
using barfootPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
     
    }
}
