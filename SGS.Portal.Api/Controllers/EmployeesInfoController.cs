using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGS.Portal.Api.Models;
using SGS.Portal.Api.ViewModels;

namespace SGS.Portal.Api.Controllers
{
    public class EmployeesInfoController : BaseController
    {
        public EmployeesInfoController(IMapper mapper,
            ILogger<EmployeesInfoController> logger) : base(mapper, logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<EmployeeInfoViewModel>>> Get()
        {
            var empsInfo = new List<EmployeeInfo>
            {
                new EmployeeInfo{
                Id = 1,
                Code = "917",
                Name = "Sameer"
                },
                new EmployeeInfo{
                Id = 2,
                Code = "1143",
                Name = "osama"
                },
            };

            return await Task.FromResult(_mapper.Map<List<EmployeeInfoViewModel>>( empsInfo ));
        }

        [HttpGet("{code}", Name = "[controller]_ByCode")]
        public async Task<ActionResult<EmployeeInfoViewModel>> GetByCode(string code)
        {
            var empInfo = new EmployeeInfo
            {
                Id = 1,
                Code = "917",
                Name = "Sameer"
            };

            return await Task.FromResult(_mapper.Map<EmployeeInfoViewModel>(empInfo));
        }
    }
}
