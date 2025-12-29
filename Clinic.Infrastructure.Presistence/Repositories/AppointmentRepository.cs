using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.Repositories.contract;
using Clinic.Infrastructure.Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Presistence.Repositories;
public class AppointmentRepository:GenericRepository<Appointment,int>, IAppointmentRepository
{
    private readonly ApplicationContext _context;
    public AppointmentRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
    //-------------------------------------------------------------------------

    public async Task<IEnumerable<DateTime>> GetAvailableSlotsAsync(DateTime date)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == DefaultUser.DoctorId);
        if(doctor == null)
            throw new KeyNotFoundException("Doctor not found");

        var dayOfWeek = date.DayOfWeek;

        var workingDay = doctor.WorkingDays.FirstOrDefault(wd => wd.Day == dayOfWeek && !wd.IsDeleted);
        if(workingDay == null || workingDay.StartTime == null || workingDay.EndTime == null)
            throw new KeyNotFoundException("Doctor not Worke in this Day");

        var startTime = workingDay.StartTime.Value;
        var endTime = workingDay.EndTime.Value;

        var current = date.Date.Add(startTime.ToTimeSpan());
        var end = date.Date.Add(endTime.ToTimeSpan());

        var appointments =  await _context.Appointments.ToListAsync();
        var existingAppointments = appointments
            .Where(a => a.DoctorId == doctor.Id && a.AppointmentDate.Date == date.Date && a.AppointmentStatus != AppointmentStatus.Cancelled)
            .ToList();

        var availableSlots = new List<DateTime>();

        while(current + TimeSpan.FromMinutes(15) <= end) 
        {
            bool isOverlapping = existingAppointments.Any(a =>
            {
                var duration = a.appointmentType switch
                {
                    AppointmentType.Regular => doctor.ConsultationDurationInMinutes,
                    AppointmentType.FollowUp => doctor.FollowUpDurationInMinutes,
                    _ => doctor.ConsultationDurationInMinutes
                };

                var appointmentStart = a.AppointmentDate;
                var appointmentEnd = appointmentStart.AddMinutes(duration);

                return current < appointmentEnd && current.AddMinutes(doctor.ConsultationDurationInMinutes) > appointmentStart;
            });

            if(!isOverlapping)
            {
                availableSlots.Add(current);
            }

            current = current.AddMinutes(doctor.ConsultationDurationInMinutes); 
        }

        return availableSlots;
    }
    //------------------------------------------------------------------------------------------
    public async Task<bool> IsSlotAvailable(DateTime slot)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d=>d.Id== DefaultUser.DoctorId);
        if(doctor == null)
            throw new KeyNotFoundException("Doctor not found");

        var appointments = await _context.Appointments.ToListAsync();
        var doctorAppointments = appointments
            .Where(a => a.DoctorId == doctor.Id && a.AppointmentDate.Date == slot.Date && !a.IsDeleted)
            .ToList();

        foreach(var appointment in doctorAppointments)
        {
            var duration = appointment.appointmentType switch
            {
                AppointmentType.Regular => doctor.ConsultationDurationInMinutes,
                AppointmentType.FollowUp => doctor.FollowUpDurationInMinutes,
                _ => doctor.ConsultationDurationInMinutes
            };

            var start = appointment.AppointmentDate;
            var end = start.AddMinutes(duration);

            if(slot < end && slot.AddMinutes(duration) > start)
                return false;
        }

        return true;
    }
    //------------------------------------------------------------------------------------------
}
