using SGS.Portal.Api.Services;

namespace SGS.Portal.Api.Models
{
    public class EmployeeInfo : IApiModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
