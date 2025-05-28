using AutoMapper;
using Clinic.Core.Application.Abstraction.AvailableLabTest;
using Clinic.Core.Application.Abstraction.AvailableLabTest.Models;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Services.AvailableLabTestServices;
internal class AvailableLabTestService(IUnitOfWork unitOfWork,IMapper mapper):IAvailableLabTestService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    //------------------------------------------------------------------------------------

    public async Task<IEnumerable<AvailableLabTestDTO>> GetAllAvailableLabTestAsync()
    {
        var AvailableLabTest = await _unitOfWork.GetRepository<AvailableLabTest,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<AvailableLabTestDTO>>(AvailableLabTest);
    }

    public async Task<AvailableLabTestDTO> GetAvailableLabTestByIdAsync(int id)
    {
        var AvailableLabTest = await _unitOfWork.GetRepository<AvailableLabTest,int>().GetByIdAsync(id);
        if(AvailableLabTest == null)
        {
            throw new KeyNotFoundException($"Available Lab Test with ID {id} not found.");
        }
        return _mapper.Map<AvailableLabTestDTO>(AvailableLabTest);
    }

    public async Task<IEnumerable<AvailableLabTestDTO>> GetAllIncludingDeletedAsync()
    {
       var AvailableLabTest = await _unitOfWork.GetRepository<AvailableLabTest,int>().GetAllIncludingDeletedAsync();
        return _mapper.Map<IEnumerable<AvailableLabTestDTO>>(AvailableLabTest);
    }

    public async Task<IEnumerable<AvailableLabTestDTO>> GetDeletedOnlyAsync()
    {
        var AvailableLabTest = await _unitOfWork.GetRepository<AvailableLabTest,int>().GetDeletedOnlyAsync();
        return _mapper.Map<IEnumerable<AvailableLabTestDTO>>(AvailableLabTest);
    }

    public async Task AddAvailableLabTestAsync(AddAvailableLabTestDTO Entity)
    {
        if(Entity == null)
        {
            throw new ArgumentNullException(nameof(Entity),"Entity cannot be null");
        }
        if(string.IsNullOrWhiteSpace(Entity.TestName))
        {
            throw new ArgumentException("Test name cannot be empty",nameof(Entity.TestName));
        }
        if(Entity.Price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(Entity.Price),"Price must be greater than zero");
        }
        Entity.LabTechnicianId = DefaultUser.LabTechnicianId;
        var newAvailableLabTest = _mapper.Map<AvailableLabTest>(Entity);
        await _unitOfWork.GetRepository<AvailableLabTest,int>().AddAsync(newAvailableLabTest);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAvailableLabTestAsync(UpdateAvailableLabTestDTO Entity)
    {
        var AvailableLabTestRepo = _unitOfWork.GetRepository<AvailableLabTest,int>();
        var existingAvailableLabTest =await  AvailableLabTestRepo.GetByIdAsync(Entity.Id);
        if(existingAvailableLabTest == null)
        {
            throw new KeyNotFoundException($"Available LabTest with ID {Entity.Id} not found.");
        }
        _mapper.Map(Entity,existingAvailableLabTest);
        AvailableLabTestRepo.UpdateAsync(existingAvailableLabTest);
        await _unitOfWork.CompleteAsync();

    }

    public async Task HardDeleteAvailableLabTestAsync(int id)
    {
        await _unitOfWork.GetRepository<AvailableLabTest,int>().HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task SoftDeleteAvailableLabTestAsync(int id)
    {
        await _unitOfWork.GetRepository<AvailableLabTest,int>().SoftDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RestoreAvailableLabTestAsync(int id)
    {
        await _unitOfWork.GetRepository<AvailableLabTest,int>().RestoreByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }

}
