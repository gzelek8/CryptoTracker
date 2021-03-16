using CryptoTracker.ApplicationServices.API.Domain.Transaction;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Add;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Put;
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
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTransactions([FromQuery] GetTransactionsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{transactionId}")]
        public async Task<IActionResult> GetById([FromRoute] int transactionId)
        {

            var request = new GetTransactionByIdRequest()
            {
                TransactionId = transactionId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTransaction([FromQuery] AddTransactionRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutTransaction([FromQuery] PutTransactionRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteTransaction([FromQuery] DeleteTransactionRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
