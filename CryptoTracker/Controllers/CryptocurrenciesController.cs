using CryptoTracker.ApplicationServices.API.Domain;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Add;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Put;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetCryptocurrencies([FromQuery] GetCryptocurrenciesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{cryptocurrencyId}")]
        public async Task<IActionResult> GetById([FromRoute] int cryptocurrencyId)
        {

            var request = new GetCryptocurrencyByIdRequest()
            {
                CryptocurrencyId = cryptocurrencyId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCryptocurrency([FromQuery] AddCryptocurrencyRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutCryptocurrency([FromQuery] PutCryptocurrencyRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteCryptocurrency([FromQuery] DeleteCryptocurrencyRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
