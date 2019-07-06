using AutoMapper;
using Sgs.Portal.Models;
using Sgs.Portal.Shared.ViewModels;

namespace SGS.Portal.Api.MappingProfiles
{
    public abstract class PortalMappingProfile <M,VM> : Profile where M : class, IPortalModel, new() where VM : class, IApiViewModel, new()
    {
        public PortalMappingProfile()
        {
            CreateMap<M, VM>()
                .ForMember(s => s.Url, opt => opt.MapFrom<ModelUrlResolver<M, VM>>())
                .ReverseMap();
        }
    }

    public class EmployeeInfoMappingProfile : PortalMappingProfile<EmployeeInfo, EmployeeInfoViewModel>
    { }

}
