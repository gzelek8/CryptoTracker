using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Alert
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
            var alert = await queryExecutor.Execute(query);
            var mappedAlert = mapper.Map<Domain.Models.Alert>(alert);
            return new GetAlertByIdResponse()
            {
                Data = mappedAlert
            };
        }
    }
}
