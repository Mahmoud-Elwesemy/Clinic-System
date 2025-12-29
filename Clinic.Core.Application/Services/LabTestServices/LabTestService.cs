using AutoMapper;
using Clinic.Core.Application.Abstraction.LabTest;
using Clinic.Core.Application.Abstraction.LabTest.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Services.LabTestServices;
internal class LabTestService(IUnitOfWork unitOfWork):ILabTestService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    //-------------------------------------------------------------------------------
    public async Task CreateLabTestAsync(AddLabTestsDTO Entity)
    {
        if (Entity == null || Entity.AvailableLabTestIds == null)
            throw new KeyNotFoundException("لا توجد تحاليل مختارة");
        var Visit = await _unitOfWork.GetRepository<Visit,int>().GetByIdAsync(Entity.VisitId);
        if(Visit == null)
            throw new KeyNotFoundException("الزياره غير موجود");
        foreach(var availableId in Entity.AvailableLabTestIds)
        {
            var availableTest = await _unitOfWork.GetRepository<AvailableLabTest,int>().GetByIdAsync(availableId);
            if(availableTest == null || availableTest.IsDeleted)
                throw new InvalidOperationException($"التحليل بالمعرف {availableId} غير موجود أو محذوف");

            var labTest = new LabTest
            {
                VisitId = Entity.VisitId,
                AvailableLabTestId = availableId,
                CreatedDate = DateTime.UtcNow
            };
            await _unitOfWork.GetRepository<LabTest,int>().AddAsync(labTest);
        }

        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------
    public async Task UpdateLabTestAsync(UpdateLabTestsDTO Entity)
    {
        var repo = _unitOfWork.GetRepository<LabTest,int>();
        var labTest = await repo.GetByIdAsync(Entity.Id);
        if(labTest == null || labTest.IsDeleted)
            throw new KeyNotFoundException("التحليل غير موجود");
        labTest.TestResult = Entity.TestResult;
        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------
    public async Task HardDeleteLabTestAsync(int LabtestId)
    {
        var repo = _unitOfWork.GetRepository<LabTest,int>();
        var labTest = await repo.GetByIdAsync(LabtestId);

        if(labTest == null)
            throw new KeyNotFoundException("التحليل غير موجود");
        await repo.HardDeleteAsync(LabtestId);
        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------
}
