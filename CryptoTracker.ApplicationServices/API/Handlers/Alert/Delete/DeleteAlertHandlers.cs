using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Delete;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Alerts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Alert.Delete
{
    public class DeleteAlertHandler : IRequestHandler<DeleteAlertRequest, DeleteAlertResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteAlertHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteAlertResponse> Handle(DeleteAlertRequest request, CancellationToken cancellationToken)
        {
            var alert = this.mapper.Map<DataAccess.Entities.Alert>(request);
            var command = new DeleteAlertCommand()
            {
                Parameter = alert
            };
            var alertfromDb = await this.commandExecutor.Execute(command);

            return new DeleteAlertResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Alert>(alertfromDb)
            };
        }
    }
}
