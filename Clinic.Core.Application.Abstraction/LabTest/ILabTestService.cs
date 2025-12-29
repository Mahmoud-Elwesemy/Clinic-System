using Clinic.Core.Application.Abstraction.LabTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.LabTest;
public interface ILabTestService
{
    Task CreateLabTestAsync(AddLabTestsDTO Entity);
    Task UpdateLabTestAsync(UpdateLabTestsDTO Entity);
    Task HardDeleteLabTestAsync(int LabtestId);
}
