using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Put;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Transaction.Put
{
    public class PutTransactionHandler : IRequestHandler<PutTransactionRequest, PutTransactionResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutTransactionHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutTransactionResponse> Handle(PutTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = this.mapper.Map<DataAccess.Entities.Transaction>(request);
            var command = new PutTransactionCommand()
            {
                Parameter = transaction
            };
            var transactionfromDb = await this.commandExecutor.Execute(command);

            return new PutTransactionResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Transaction>(transactionfromDb)
            };
        }
    }
}
