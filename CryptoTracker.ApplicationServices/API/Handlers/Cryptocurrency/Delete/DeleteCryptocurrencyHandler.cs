using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Delete;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Cryptocurrencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Cryptocurrency.Delete
{
    public class DeleteCryptocurrencyHandler : IRequestHandler<DeleteCryptocurrencyRequest, DeleteCryptocurrencyResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteCryptocurrencyHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteCryptocurrencyResponse> Handle(DeleteCryptocurrencyRequest request, CancellationToken cancellationToken)
        {
            var cryptocurrency = this.mapper.Map<DataAccess.Entities.Cryptocurrency>(request);
            var command = new DeleteCryptocurrencyCommand()
            {
                Parameter = cryptocurrency
            };
            var cryptocurrencyfromDb = await this.commandExecutor.Execute(command);

            return new DeleteCryptocurrencyResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Cryptocurrency>(cryptocurrencyfromDb)
            };
        }
    }
}
