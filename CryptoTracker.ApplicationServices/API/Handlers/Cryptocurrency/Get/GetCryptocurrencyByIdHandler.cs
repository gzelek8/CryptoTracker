using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Queries.Cryptocurrencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Cryptocurrency
{
    public class GetCryptocurrencyByIdHandler : IRequestHandler<GetCryptocurrencyByIdRequest, GetCryptocurrencyByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCryptocurrencyByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCryptocurrencyByIdResponse> Handle(GetCryptocurrencyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCryptocurrencyQuery()
            {
                Id = request.CryptocurrencyId
            };

            var cryptocurrency = await this.queryExecutor.Execute(query);

            var mappedCryptocurrency = this.mapper.Map<Domain.Models.Cryptocurrency>(cryptocurrency);

            return new GetCryptocurrencyByIdResponse()
            {
                Data = mappedCryptocurrency
            };

        }
    }
}
