using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DesafioWooza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoTelefoniaController : ControllerBase
    {

        private readonly ILogger<PlanoTelefoniaController> _logger;

        public PlanoTelefoniaController(ILogger<PlanoTelefoniaController> logger)
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
