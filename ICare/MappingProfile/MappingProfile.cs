using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ICare.Shared.Models.StaticValues;
using ICare.ViewModel;

namespace ICare.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StaticValuesViewModal, StaticValuesModel>()
            .ForMember(dest => dest.AdditionalValue, opt => opt.MapFrom(src => src.AdditionalField))
            .ForMember(dest => dest.AdditionalValue2, opt => opt.MapFrom(src => src.AdditionalField2))
            .ForMember(dest => dest.AdditionalValue3, opt => opt.MapFrom(src => src.AdditionalField3))
            .ForMember(dest => dest.AdditionalValue4, opt => opt.MapFrom(src => src.AdditionalField4))
            .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.CatalogueType))                        
            .ForMember(dest => dest.AccountType, o => o.Ignore())            
            .ForMember(dest => dest.Sno, o => o.Ignore())            
            .ReverseMap();
        }
    }
}
