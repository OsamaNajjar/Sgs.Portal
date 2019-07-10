using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace SGS.Portal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        public const string URLHELPER = "URLHELPER";
        public const string CONTROLLER_NAME = "CONTROLLER_NAME";

        public const string NOTFOUND_MESSAGE = "Data Not Found";

        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseController(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            context.HttpContext.Items[URLHELPER] = this.Url;
            context.HttpContext.Items[CONTROLLER_NAME] = ControllerContext.ActionDescriptor.ControllerName;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    ErrorMessage = "Validation error",
                    Errors = ModelState.Keys.Where(k => ModelState[k].Errors.Any())
                .Select(key => new { Key = key, Errors = ModelState[key].Errors.Select(x => x.ErrorMessage) })
                .ToList()
                });
            }
        }
    }
}
