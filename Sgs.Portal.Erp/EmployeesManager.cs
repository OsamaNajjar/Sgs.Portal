using Newtonsoft.Json;
using Sgs.Portal.Models;
using Sgs.Portal.Shared.Services;
using Sgs.Portal.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sgs.Portal.Erp
{
    public class EmployeesManager : IEmployeesManager
    {
        private readonly HttpClient _client;

        public EmployeesManager(HttpClient client)
        {
            _client = client;
        }

        public async Task<ICollection<EmployeeInfo>> GetAllEmployeesInfo()
        {
            try
            {
                string url = "Employees";

                HttpResponseMessage response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<EmployeeInfo>>(content);
                    foreach (var item in results)
                    {
                        item.Code = item.EmployeeId.ToString();
                    }
                    return results;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Data not found !!");
                }
                else //Else in case of BadRequest for not found data or InternalServerError
                {
                    throw new Exception("Internal Server Error");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<EmployeeInfo> GetEmployeeInfo(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeInfo> GetEmployeeInfo(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeInfo> GetManagerInfo(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           _client.Dispose();
        }

        
    }
}
