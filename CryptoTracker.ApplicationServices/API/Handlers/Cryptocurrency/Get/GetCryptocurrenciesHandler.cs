using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Queries.Cryptocurrencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers
{
    public class GetCryptocurrenciesHandler : IRequestHandler<GetCryptocurrenciesRequest, GetCryptocurrenciesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCryptocurrenciesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCryptocurrenciesResponse> Handle(GetCryptocurrenciesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCryptocurrenciesQuery()
            {
                Name = request.Name,
                Price = request.Price,
                Rank = request.Rank
            };

            var cryptocurrencies = await this.queryExecutor.Execute(query);

            var mappedCryptocurrencies = this.mapper.Map<List<Domain.Models.Cryptocurrency>>(cryptocurrencies);

            return new GetCryptocurrenciesResponse()
            {
                Data = mappedCryptocurrencies
            };
        }
    }
}
