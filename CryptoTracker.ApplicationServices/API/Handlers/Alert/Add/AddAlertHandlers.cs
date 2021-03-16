using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Add;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Alerts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Alert.Add
{
    public class AddAlertHandler : IRequestHandler<AddAlertRequest, AddAlertResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddAlertHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddAlertResponse> Handle(AddAlertRequest request, CancellationToken cancellationToken)
        {
            var alert = this.mapper.Map<DataAccess.Entities.Alert>(request);
            var command = new AddAlertCommand()
            {
                Parameter = alert
            };
            var alertfromDb = await this.commandExecutor.Execute(command);

            return new AddAlertResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Alert>(alertfromDb)
            };

        }
    }
}
