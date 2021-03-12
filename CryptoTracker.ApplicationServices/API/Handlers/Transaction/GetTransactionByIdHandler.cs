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
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdRequest, GetTransactionByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetTransactionByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetTransactionByIdResponse> Handle(GetTransactionByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTransactionQuery()
            {
                Id = request.TransactionId
            };
            var transaction = await queryExecutor.Execute(query);
            var mappedTransaction = mapper.Map<Domain.Models.Transaction>(transaction);
            return new GetTransactionByIdResponse()
            {
                Data = mappedTransaction
            };
        }
    }
}
