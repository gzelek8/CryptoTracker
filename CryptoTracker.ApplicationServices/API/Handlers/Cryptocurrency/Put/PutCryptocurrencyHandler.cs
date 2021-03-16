using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Put;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Cryptocurrencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Cryptocurrency.Put
{
    public class PutCryptocurrencyHandler : IRequestHandler<PutCryptocurrencyRequest, PutCryptocurrencyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutCryptocurrencyHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutCryptocurrencyResponse> Handle(PutCryptocurrencyRequest request, CancellationToken cancellationToken)
        {
            var cryptocurrency = this.mapper.Map<DataAccess.Entities.Cryptocurrency>(request);
            var command = new PutCryptocurrencyCommand()
            {
                Parameter = cryptocurrency
            };
            var cryptocurrencyfromDb = await this.commandExecutor.Execute(command);

            return new PutCryptocurrencyResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Cryptocurrency>(cryptocurrencyfromDb)
            };
        }
    }
}
