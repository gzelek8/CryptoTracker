using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.User;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Queries.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.User
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery()
            {
                Nick = request.Nick
            };
            var users = await queryExecutor.Execute(query);
            var mappedUsers = mapper.Map<List<Domain.Models.User>>(users);
            return new GetUsersResponse()
            {
                Data = mappedUsers
            };
        }
    }
}
