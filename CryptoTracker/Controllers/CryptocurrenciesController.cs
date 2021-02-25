using CryptoTracker.ApplicationServices.API.Domain;
using CryptoTracker.DataAccess;
using CryptoTracker.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptocurrenciesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CryptocurrenciesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCryptocurrencies([FromQuery] GetCryptocurrenciesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
