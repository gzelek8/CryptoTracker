using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.User.Put;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Alerts;
using CryptoTracker.DataAccess.CQRS.Commands.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.User.Put
{
    public class PutUserHandler : IRequestHandler<PutUserRequest, PutUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutUserResponse> Handle(PutUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var command = new PutUserCommand()
            {
                Parameter = user
            };
            var userUpdated = await this.commandExecutor.Execute(command);

            return new PutUserResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.User>(userUpdated)
            };
        }
    }
}
