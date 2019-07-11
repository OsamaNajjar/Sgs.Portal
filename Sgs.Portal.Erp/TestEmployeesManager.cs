using Sgs.Portal.Models;
using Sgs.Portal.Shared.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sgs.Portal.Erp
{
    public class TestEmployeesManager : IEmployeesManager
    {
        private readonly HttpClient _client;

        public TestEmployeesManager(HttpClient client)
        {
            _client = client;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<ICollection<EmployeeInfo>> GetAllEmployeesInfo()
        {
            return await Task.FromResult<ICollection<EmployeeInfo>>(new List<EmployeeInfo> {
                new EmployeeInfo
                {
                    Code="917",
                    EmployeeId=917,
                    Name="sameer"
                },
                new EmployeeInfo
                {
                    Code="1143",
                    EmployeeId=1143,
                    Name="osama"
                },
                new EmployeeInfo
                {
                    Code="82",
                    EmployeeId=82,
                    Name="nawaf"
                }

            });
        }

        public Task<EmployeeInfo> GetEmployeeInfo(string code)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeInfo> GetEmployeeInfo(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeInfo> GetManagerInfo(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
