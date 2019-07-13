using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Portal.Shared.Services;
using Sgs.Portal.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGS.Portal.Api.Controllers
{
    public class EmployeesInfoController : BaseController
    {
        private readonly IEmployeesManager _employeesManager;

        public EmployeesInfoController(IEmployeesManager employeesManager,IMapper mapper,
            ILogger<EmployeesInfoController> logger) : base(mapper, logger)
        {
            _employeesManager = employeesManager;
        }

        [HttpGet]
        [EnableQuery()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ICollection<EmployeeInfoViewModel>>> Get()
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GettingDataStart, "Start getting all employees data");
                using (_employeesManager)
                {
                    var employeesList = await _employeesManager.GetAllEmployeesInfo();
                    return _mapper.Map<List<EmployeeInfoViewModel>>(employeesList);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GettingDataError,ex,$"Error while getting all employees data !. error message : {ex.Message}");
            }

            return BadRequest();
        }

        [HttpGet("{code}", Name = "[controller]_ByCode")]
        public async Task<ActionResult<EmployeeInfoViewModel>> GetByCode(string code)
        {
            try
            {
                using (_employeesManager)
                {
                    var employeeInfo = await _employeesManager.GetEmployeeInfo(code);

                    if (employeeInfo == null)
                        return BadRequest(new { ErrorMessage = NOTFOUND_MESSAGE });

                    return _mapper.Map<EmployeeInfoViewModel>(employeeInfo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GettingDataError,$"Error while getting employee data by code !. error message : {ex.Message}");
            }

            return BadRequest();
        }

    }
}
