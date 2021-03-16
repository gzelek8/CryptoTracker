using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Wallet;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Queries.Wallets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Wallet
{
    public class GetWalletsHandler : IRequestHandler<GetWalletsRequest, GetWalletsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetWalletsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetWalletsResponse> Handle(GetWalletsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetWalletsQuery()
            {
                UserId = request.UserId
            };
            var wallets = await queryExecutor.Execute(query);
            var mappedWallets = mapper.Map<List<Domain.Models.Wallet>>(wallets);
            return new GetWalletsResponse()
            {
                Data = mappedWallets
            };

        }
    }
}
