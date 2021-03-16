using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Add;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Transaction.Add
{
    public class AddTransactionHandler : IRequestHandler<AddTransactionRequest, AddTransactionResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddTransactionHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddTransactionResponse> Handle(AddTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = this.mapper.Map<DataAccess.Entities.Transaction>(request);
            var command = new AddTransactionCommand()
            {
                Parameter = transaction
            };
            var transactionfromDb = await this.commandExecutor.Execute(command);

            return new AddTransactionResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Transaction>(transactionfromDb)
            };

        }
    }
}
