using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Add;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Cryptocurrencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Cryptocurrency.Add
{
    public class AddCryptocurrencyHandler : IRequestHandler<AddCryptocurrencyRequest, AddCryptocurrencyResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddCryptocurrencyHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddCryptocurrencyResponse> Handle(AddCryptocurrencyRequest request, CancellationToken cancellationToken)
        {
            var cryptocurrency = this.mapper.Map<DataAccess.Entities.Cryptocurrency>(request);
            var command = new AddCryptocurrencyCommand()
            {
                Parameter = cryptocurrency
            };
            var cryptocurrencyfromDb = await this.commandExecutor.Execute(command);

            return new AddCryptocurrencyResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Cryptocurrency>(cryptocurrencyfromDb)
            };

        }
    }
}
