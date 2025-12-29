using AutoMapper;
using Clinic.Core.Application.Abstraction.Medicine;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;

namespace Clinic.Core.Application.Services.MedicineServices;
internal class MedicineService(IUnitOfWork unitOfWork,IMapper mapper):IMedicineService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    //--------------------------------------------------------------------------------------
    private async Task<bool> IsMedicineNameExistsAsync(string name,int? excludeId = null)
    {
        var medicines = await _unitOfWork.GetRepository<Medicine,int>().GetAllAsync();
        return medicines.Any(m =>
            !m.IsDeleted &&
            m.Name.Trim().ToLower() == name.Trim().ToLower() &&
            (!excludeId.HasValue || m.Id != excludeId.Value)
        );
    }
    //--------------------------------------------------------------------------------------
    public async Task<IEnumerable<MedicineDTO>> GetMedicinesAsync()
    {
        var medicines = await _unitOfWork.GetRepository<Medicine,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
    }
    //------------------------------------------------------------------------------------------
    public async Task<MedicineDTO> GetMedicineByIdAsync(int id)
    {
        var medicine = await _unitOfWork.GetRepository<Medicine,int>().GetByIdAsync(id);
        if(medicine == null)
            throw new KeyNotFoundException($"Medicine with ID {id} not found.");
        return _mapper.Map<MedicineDTO>(medicine);
    }
    //------------------------------------------------------------------------------------------
    public async Task AddMedicineAsync(AddMedicineDTO Entity)
    {
        if(Entity == null)
            throw new ArgumentNullException(nameof(Entity),"Entity cannot be null");
        if(string.IsNullOrWhiteSpace(Entity.Name))
            throw new ArgumentException("Medicine name cannot be empty",nameof(Entity.Name));
        if(Entity.Price <= 0)
            throw new ArgumentOutOfRangeException(nameof(Entity.Price),"Price must be greater than zero");
        
        if(await IsMedicineNameExistsAsync(Entity.Name))
            throw new InvalidOperationException($"A medicine named '{Entity.Name}' already exists.");
        
        Entity.PharmacistId = DefaultUser.PharmacistId;
        var newMedicine = _mapper.Map<Medicine>(Entity);
        await _unitOfWork.GetRepository<Medicine,int>().AddAsync(newMedicine);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task UpdateMedicineAsync(UpdateMedicineDTO Entity)
    {
        var MedicineRepo = _unitOfWork.GetRepository<Medicine,int>();
        var existingMedicine = await MedicineRepo.GetByIdAsync(Entity.Id);
        if(existingMedicine == null)
            throw new KeyNotFoundException($"Medicine with ID {Entity.Id} not found.");

        if(await IsMedicineNameExistsAsync(Entity.Name,Entity.Id))
            throw new InvalidOperationException($"Another medicine named '{Entity.Name}' already exists.");

        _mapper.Map(Entity,existingMedicine);
        MedicineRepo.UpdateAsync(existingMedicine);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<MedicineDTO>> GetAllIncludingDeletedAsync()
    {
        var result = await _unitOfWork.GetRepository<Medicine,int>().GetAllIncludingDeletedAsync();
        return _mapper.Map<IEnumerable<MedicineDTO>>(result);
    }
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<MedicineDTO>> GetDeletedOnlyAsync()
    {
        var result = await _unitOfWork.GetRepository<Medicine,int>().GetDeletedOnlyAsync();
        return _mapper.Map<IEnumerable<MedicineDTO>>(result);
    }
    //------------------------------------------------------------------------------------------
    public async Task HardDeleteMedicineAsync(int id)
    {
        await _unitOfWork.GetRepository<Medicine,int>().HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task SoftDeleteMedicineAsync(int id)
    {
        await _unitOfWork.GetRepository<Medicine,int>().SoftDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task RestoreMedicineAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<Medicine,int>();
        var medicine = await repo.GetByIdAsync(id);
        if(medicine == null)
            throw new KeyNotFoundException($"Medicine with ID {id} not found.");

        if(!medicine.IsDeleted)
            throw new InvalidOperationException("This medicine is already active.");

        if(await IsMedicineNameExistsAsync(medicine.Name,id))
            throw new InvalidOperationException($"Cannot restore: a medicine with the name '{medicine.Name}' already exists.");
        await repo.RestoreByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
}
