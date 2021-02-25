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
        private readonly IRepository<DataAccess.Entities.Cryptocurrency> cryptocurrencyRepository;

        public GetCryptocurrenciesHandler(IRepository<CryptoTracker.DataAccess.Entities.Cryptocurrency> cryptocurrencyRepository)
        {
            this.cryptocurrencyRepository = cryptocurrencyRepository;
        }

        public Task<GetCryptocurrenciesResponse> Handle(GetCryptocurrenciesRequest request, CancellationToken cancellationToken)
        {
            var cryptocurrencies = this.cryptocurrencyRepository.GetAll();
            var domainCryptocurrencies = cryptocurrencies.Select(x => new Domain.Models.Cryptocurrency()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Rank = x.Rank,
            });

            var response = new GetCryptocurrenciesResponse()
            {
                Data = domainCryptocurrencies.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
