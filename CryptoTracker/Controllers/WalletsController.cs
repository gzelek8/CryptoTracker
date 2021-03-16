using CryptoTracker.ApplicationServices.API.Domain.Wallet;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Add;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Put;
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
    public class WalletsController : ControllerBase
    {
        private readonly IMediator mediator;

        public WalletsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetWallets([FromQuery] GetWalletsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{walletId}")]
        public async Task<IActionResult> GetById([FromRoute] int walletId)
        {

            var request = new GetWalletByIdRequest()
            {
                WalletId = walletId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddWallet([FromQuery] AddWalletRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutWallet([FromQuery] PutWalletRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteWallet([FromQuery] DeleteWalletRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
