using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using CryptoTracker.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers
{
    public class GetCryptocurrenciesHandler : IRequestHandler<GetCryptocurrenciesRequest, GetCryptocurrenciesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor queryExecutor;

        public GetCryptocurrenciesHandler(IMapper mapper, IQuerryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCryptocurrenciesResponse> Handle(GetCryptocurrenciesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCryptocurrenciesQuerry();

            var cryptocurrencies = await this.queryExecutor.Execute(query);

            var mappedCryptocurrencies = this.mapper.Map<List<Domain.Models.Cryptocurrency>>(cryptocurrencies);

            return new GetCryptocurrenciesResponse()
            {
                Data = mappedCryptocurrencies
            };
        }
    }
}
