using AutoMapper;
using SGS.Portal.Api.Models;
using SGS.Portal.Api.Services;
using SGS.Portal.Api.ViewModels;

namespace SGS.Portal.Api.MappingProfiles
{
    public abstract class PortalMappingProfile <M,VM> : Profile where M : class, IApiModel, new() where VM : class, IApiViewModel, new()
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
