using Sgs.Portal.Shared.ViewModels;
using System.Threading.Tasks;

namespace Sgs.Portal.Shared.Services
{
    public interface IEmployeesManager
    {

        Task<EmployeeInfoViewModel> GetAllEmployeesInfo(int employeeId);

        Task<EmployeeInfoViewModel> GetEmployeeInfo(int employeeId);

        Task<EmployeeInfoViewModel> GetManagerInfo(int employeeId);

    }
}
