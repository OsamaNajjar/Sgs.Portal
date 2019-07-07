using Sgs.Portal.Shared.Services;

namespace Sgs.Portal.Shared.ViewModels
{
    public class EmployeeInfoViewModel : IApiViewModel
    {
        public string Url { get; set; }

        public string Code { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; }

    }
}
