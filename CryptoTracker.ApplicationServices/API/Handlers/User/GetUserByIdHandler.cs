using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.User;
using CryptoTracker.DataAccess.CQRS.Queries.Users;
using MediatR;
using Remotion.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.UserId
            };
            var user = await queryExecutor.Execute(query);
            var mappedUser = mapper.Map<Domain.Models.User>(user);
            return new GetUserByIdResponse()
            {
                Data = mappedUser
            };
        }
    }
}
