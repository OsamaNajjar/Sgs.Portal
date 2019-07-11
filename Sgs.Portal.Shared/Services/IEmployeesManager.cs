using Sgs.Portal.Models;
using Sgs.Portal.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sgs.Portal.Shared.Services
{
    public interface IEmployeesManager : IDisposable
    {

        Task<ICollection<EmployeeInfo>> GetAllEmployeesInfo();

        Task<EmployeeInfo> GetEmployeeInfo(string code);

        Task<EmployeeInfo> GetEmployeeInfo(int employeeId);

        Task<EmployeeInfo> GetManagerInfo(int employeeId);

    }
}
