using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Delete;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Transaction.Delete
{
    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionRequest, DeleteTransactionResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteTransactionHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteTransactionResponse> Handle(DeleteTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = this.mapper.Map<DataAccess.Entities.Transaction>(request);
            var command = new DeleteTransactionCommand()
            {
                Parameter = transaction
            };
            var transactionfromDb = await this.commandExecutor.Execute(command);

            return new DeleteTransactionResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Transaction>(transactionfromDb)
            };
        }
    }
}
