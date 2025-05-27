using AutoMapper;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Application.Abstraction.Auth.Model;
using Clinic.Core.Application.Abstraction.Medicine.Models;
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
        CreateMap<Medicine,MedicineDTO>()
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.QuantityAvailable,opt => opt.MapFrom(src => src.QuantityAvailable))
            .ForMember(dest => dest.PharmacistName,opt => opt.MapFrom(src => src.Pharmacist!.FullName))
            .ReverseMap();
        CreateMap<Medicine,AddMedicineDTO>()
            .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.QuantityAvailable,opt => opt.MapFrom(src => src.QuantityAvailable))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PharmacistId,opt => opt.MapFrom(src => src.PharmacistId))
            .ReverseMap();
        CreateMap<Medicine,UpdateMedicineDTO>()
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.QuantityAvailable,opt => opt.MapFrom(src => src.QuantityAvailable))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => src.Price))
            .ReverseMap();
        CreateMap<Appointment,AppointmentDto>()
            .ForMember(dest => dest.PatientName,opt => opt.MapFrom(src => src.Patient!.FullName))
            .ForMember(dest => dest.DoctorName,opt => opt.MapFrom(src => src.DoctorId))
            .ReverseMap();
        CreateMap<Appointment,AddAppointmentDto>()
            .ForMember(dest => dest.PatientId,opt => opt.MapFrom(src => src.PatientId))
            .ForMember(dest => dest.DoctorId,opt => opt.MapFrom(src => src.DoctorId))

            .ReverseMap();


    }
}
