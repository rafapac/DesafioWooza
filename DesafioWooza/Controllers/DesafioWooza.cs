using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DesafioWooza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesafioWooza : ControllerBase
    {

        private readonly ILogger<DesafioWooza> _logger;

        public DesafioWooza(ILogger<DesafioWooza> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }
    }
}
