using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGS.Portal.Api.Controllers;
using SGS.Portal.Api.Services;

namespace SGS.Portal.Api.MappingProfiles
{
    public class ModelUrlResolver<M, VM> : IValueResolver<M, VM, string> where M : class, IApiModel , new() where VM : class, IApiViewModel, new()
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
