using Sgs.Portal.Models;
using Sgs.Portal.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sgs.Portal.Shared.Services
{
    public interface IEmployeesManager
    {

        Task<List<EmployeeInfo>> GetAllEmployeesInfo();

        Task<EmployeeInfoViewModel> GetEmployeeInfo(int employeeId);

        Task<EmployeeInfoViewModel> GetManagerInfo(int employeeId);

    }
}
