
using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Queries.Alerts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Alert.Get
{
    public class GetAlertsHandler : IRequestHandler<GetAlertsRequest, GetAlertsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAlertsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAlertsResponse> Handle(GetAlertsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAlertsQuery()
            {
                PriceAlert = request.PriceAlert,
                CryptocurrencyId = request.CryptocurrencyId,
                UserId = request.UserId
            };

            var alert = await this.queryExecutor.Execute(query);
            var mappedAlert = this.mapper.Map<List<Domain.Models.Alert>>(alert);

            var response = new GetAlertsResponse()
            {
                Data = mappedAlert
            };
            return response;
        }
    }
}
