using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgs.Portal.Models;
using Sgs.Portal.Shared.ViewModels;
using SGS.Portal.Api.Controllers;

namespace SGS.Portal.Api.MappingProfiles
{
    public class ModelUrlResolver<M, VM> : IValueResolver<M, VM, string> where M : class, IPortalModel , new() where VM : class, IApiViewModel, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ModelUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(M source, VM destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            var controllerName = _httpContextAccessor.HttpContext.Items[BaseController.CONTROLLER_NAME];
            string result = url.Link($"{controllerName}_ByCode", new { code = source.Code });
            return result;
        }
    }
}
