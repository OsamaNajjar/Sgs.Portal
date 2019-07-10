namespace Sgs.Portal.Models
{
    public class EmployeeInfo : IPortalModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; }
    }
}
