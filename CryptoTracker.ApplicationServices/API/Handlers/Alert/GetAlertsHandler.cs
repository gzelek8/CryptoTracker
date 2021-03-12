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
            var query = new GetAlertsQuery();
            var alerts = await queryExecutor.Execute(query);
            var mappedBoards = mapper.Map<List<Domain.Models.Alert>>(alerts);
            return new GetAlertsResponse()
            {
                Data = mappedBoards
            };

        }
    }
}
