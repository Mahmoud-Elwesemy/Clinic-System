using AutoMapper;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Application.Abstraction.Auth.Model;
using Clinic.Core.Application.Abstraction.AvailableLabTest.Models;
using Clinic.Core.Application.Abstraction.Diagnosis.Models;
using Clinic.Core.Application.Abstraction.LabTest.Models;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Application.Abstraction.Visit.Models;
using Clinic.Core.Application.Abstraction.WorkingDay.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities.Users;

namespace Clinic.Core.Application.Mapping;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        #region Configratio Of Account
        CreateMap<RegisterPatientDTO,Patient>()
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

        #region  Configratio Of Medicine
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
        #endregion

        #region  Configratio Of Appointment
        CreateMap<Appointment,AppointmentDto>()
             .ForMember(dest => dest.DoctorName,opt => opt.MapFrom(src => src.Doctor != null ? src.Doctor.FullName : null))
             .ForMember(dest => dest.PatientName,opt => opt.MapFrom(src => src.Patient != null ? src.Patient.FullName : null))
             .ReverseMap();
        CreateMap<Appointment,AddAppointmentDto>()
            .ForMember(dest => dest.PatientId,opt => opt.MapFrom(src => src.PatientId))
            .ForMember(dest => dest.DoctorId,opt => opt.MapFrom(src => src.DoctorId))
            .ReverseMap(); 
        CreateMap<Appointment,UpdateAppointmentDto>().ReverseMap();
        #endregion

        #region  Configratio Of AvailableLabTest
        CreateMap<AvailableLabTest,AvailableLabTestDTO>()
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TestName,opt => opt.MapFrom(src => src.TestName))
            .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.LabTechnicianName,opt => opt.MapFrom(src => src.LabTechnician!.FullName))
            .ForMember(dest => dest.LabTechnicianId,opt => opt.MapFrom(src => src.LabTechnicianId))
            .ReverseMap();
        CreateMap<AvailableLabTest,AddAvailableLabTestDTO>()
            .ForMember(dest => dest.TestName,opt => opt.MapFrom(src => src.TestName))
            .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => src.Price))         
            .ReverseMap();
        CreateMap<AvailableLabTest,UpdateAvailableLabTestDTO>()
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TestName,opt => opt.MapFrom(src => src.TestName))
            .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => src.Price))
            .ReverseMap();
        #endregion

        #region Configratio Of WorkingDay
        CreateMap<WorkingDay,WorkingDayDTO>().ReverseMap();
        CreateMap<WorkingDay,AddWorkingDayDTO>().ReverseMap();
        CreateMap<WorkingDay,UpdateWorkingDayDTO>().ReverseMap();
        #endregion

        #region Configratio Of Visit
        CreateMap<Visit,VisitDTO>()
          .ForMember(dest => dest.PatientFullName,
              opt => opt.MapFrom(src => src.Patient.FullName))
          .ForMember(dest => dest.DoctorFullName,
              opt => opt.MapFrom(src => src.Doctor.FullName))
          .ReverseMap();

        CreateMap<AddVisitDTO,Visit>().ReverseMap();
        CreateMap<UpdateVisitDTO,Visit>().ReverseMap();
        #endregion

        #region Configratio Of Diagnosis
        CreateMap<Diagnosis,DiagnosisDTO>().ReverseMap();
        CreateMap<Diagnosis,AddDiagnosisDTO>().ReverseMap();
        CreateMap<Diagnosis,UpdateDiagnosisDTO>().ReverseMap();
        #endregion

        #region Configratio Of LabTest
        CreateMap<LabTest,LabTestDTO>()
            .ReverseMap();

        CreateMap<LabTest,UpdateLabTestsDTO>()
            .ReverseMap(); 
        #endregion
    }
}
