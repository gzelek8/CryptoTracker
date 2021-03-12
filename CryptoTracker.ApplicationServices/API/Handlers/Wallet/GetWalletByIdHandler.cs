using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Wallet
{
    public class GetWalletByIdHandler : IRequestHandler<GetWalletByIdRequest, GetWalletByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetWalletByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetWalletByIdResponse> Handle(GetWalletByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetWalletQuery()
            {
                Id = request.WalletId
            };
            var wallet = await queryExecutor.Execute(query);
            var mappedWallet = mapper.Map<Domain.Models.Wallet>(wallet);
            return new GetWalletByIdResponse()
            {
                Data = mappedWallet
            };
        }
    }
}
