using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Put;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Alerts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Alert.Put
{
    public class PutAlertHandler : IRequestHandler<PutAlertRequest, PutAlertResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutAlertHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutAlertResponse> Handle(PutAlertRequest request, CancellationToken cancellationToken)
        {
            var alert = this.mapper.Map<DataAccess.Entities.Alert>(request);
            var command = new PutAlertCommand()
            {
                Parameter = alert
            };
            var alertdromDb = await this.commandExecutor.Execute(command);

            return new PutAlertResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Alert>(alertdromDb)
            };
        }
    }
}
