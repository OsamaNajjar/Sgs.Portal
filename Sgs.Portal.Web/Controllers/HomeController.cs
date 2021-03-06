﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sgs.Portal.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper, ILogger<HomeController> logger) : base(mapper, logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
