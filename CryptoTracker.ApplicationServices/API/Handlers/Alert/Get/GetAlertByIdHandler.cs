using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert;
using CryptoTracker.DataAccess.CQRS.Queries.Alerts;
using CryptoTracker.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Alert.Get
{
    public class GetAlertByIdHandler : IRequestHandler<GetAlertByIdRequest, GetAlertByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAlertByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAlertByIdResponse> Handle(GetAlertByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAlertQuery()
            {
                Id = request.AlertId
            };
            var alert = await this.queryExecutor.Execute(query);
            var mappedAlert = this.mapper.Map<Domain.Models.Alert>(alert);
            var response = new GetAlertByIdResponse()
            {
                Data = mappedAlert
            };
            return response;
        }
    }
}
