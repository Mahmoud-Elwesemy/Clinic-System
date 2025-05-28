using AutoMapper;
using Clinic.Core.Application.Abstraction.Medicine;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Services.MedicineServices;
internal class MedicineService(IUnitOfWork unitOfWork,IMapper mapper):IMedicineService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    //--------------------------------------------------------------------------------------

    public async Task<IEnumerable<MedicineDTO>> GetMedicinesAsync()
    {
        var medicines = await _unitOfWork.GetRepository<Medicine,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
    }
    public async Task<MedicineDTO> GetMedicineByIdAsync(int id)
    {
        var medicine = await _unitOfWork.GetRepository<Medicine,int>().GetByIdAsync(id);
        if(medicine == null)
        {
            throw new KeyNotFoundException($"Medicine with ID {id} not found.");
        }
        return _mapper.Map<MedicineDTO>(medicine);
    }

    public async Task AddMedicineAsync(AddMedicineDTO Entity)
    {
        if(Entity == null)
        {
            throw new ArgumentNullException(nameof(Entity),"Entity cannot be null");
        }
        if(string.IsNullOrWhiteSpace(Entity.Name))
        {
            throw new ArgumentException("Medicine name cannot be empty",nameof(Entity.Name));
        }
        if(Entity.Price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(Entity.Price),"Price must be greater than zero");
        }
        Entity.PharmacistId = DefaultUser.PharmacistId;
        var newMedicine = _mapper.Map<Medicine>(Entity);
        await _unitOfWork.GetRepository<Medicine,int>().AddAsync(newMedicine);
        await _unitOfWork.CompleteAsync();
    }
    
    public async Task UpdateMedicineAsync(UpdateMedicineDTO Entity)
    {
        var MedicineRepo = _unitOfWork.GetRepository<Medicine,int>();
        var existingMedicine = await MedicineRepo.GetByIdAsync(Entity.Id);
        if(existingMedicine == null)
        {
            throw new KeyNotFoundException($"Medicine with ID {Entity.Id} not found.");
        }
        _mapper.Map(Entity,existingMedicine);
        MedicineRepo.UpdateAsync(existingMedicine);
        await _unitOfWork.CompleteAsync();
    }   

    public async Task<IEnumerable<MedicineDTO>> GetAllIncludingDeletedAsync()
    {
        var result = await _unitOfWork.GetRepository<Medicine,int>().GetAllIncludingDeletedAsync();
        return _mapper.Map<IEnumerable<MedicineDTO>>(result);
    }

    public async Task<IEnumerable<MedicineDTO>> GetDeletedOnlyAsync()
    {
        var result = await _unitOfWork.GetRepository<Medicine,int>().GetDeletedOnlyAsync();
        return _mapper.Map<IEnumerable<MedicineDTO>>(result);
    }

    public async Task HardDeleteMedicineAsync(int id)
    {
        await _unitOfWork.GetRepository<Medicine,int>().HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task SoftDeleteMedicineAsync(int id)
    {
        await _unitOfWork.GetRepository<Medicine,int>().SoftDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RestoreMedicineAsync(int id)
    {
        await _unitOfWork.GetRepository<Medicine,int>().RestoreByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}
