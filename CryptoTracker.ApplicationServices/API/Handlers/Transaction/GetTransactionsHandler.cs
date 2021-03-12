using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Transaction
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsRequest, GetTransactionsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetTransactionsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetTransactionsResponse> Handle(GetTransactionsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTransactionsQuery();
            var transactions = await queryExecutor.Execute(query);
            var mappedTransactions = mapper.Map<List<Domain.Models.Transaction>>(transactions);
            return new GetTransactionsResponse()
            {
                Data = mappedTransactions
            };

        }
    }
}
