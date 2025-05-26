using AutoMapper;
using Clinic.Core.Application.Abstraction.Auth.Model;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Mapping;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        #region Configratio Of Account
        CreateMap<RegisterPatientDTO,ApplicationUser>()
           .ForMember(dest => dest.UserName,opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.PhoneNumber,opt => opt.MapFrom(src => src.PhoneNumber))
           .ForMember(dest => dest.WhatsAppNumber,opt => opt.MapFrom(src => src.WhatsAppNumber))
           .ForMember(dest => dest.FullName,opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email,opt => opt.MapFrom(src => src.Email))
           .ReverseMap();
        #endregion
        #region Configratio Of Account Profile 
        CreateMap<AccountProfileDTO,ApplicationUser>()
            .ForMember(dest => dest.Email,opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PhoneNumber,opt => opt.MapFrom(src => src.PhoneNumber ?? "not found"))
            .ForMember(dest => dest.FullName,opt => opt.MapFrom(src => src.FullName))
            .ReverseMap();
        //CreateMap<AccountProfileDTO,ApplicationUser>().ReverseMap();
        //CreateMap<AccountProfileDTO,Doctor>().ReverseMap();

        #endregion
    }
}
