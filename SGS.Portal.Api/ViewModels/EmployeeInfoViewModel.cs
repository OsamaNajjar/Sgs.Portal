using SGS.Portal.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGS.Portal.Api.ViewModels
{
    public class EmployeeInfoViewModel : IApiViewModel
    {
        public string Url { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
