using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Delete;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Wallets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Wallet.Delete
{
    public class DeleteWalletHandler : IRequestHandler<DeleteWalletRequest, DeleteWalletResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteWalletHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteWalletResponse> Handle(DeleteWalletRequest request, CancellationToken cancellationToken)
        {
            var wallet = this.mapper.Map<DataAccess.Entities.Wallet>(request);
            var command = new DeleteWalletCommand()
            {
                Parameter = wallet
            };
            var walletFromDB = await this.commandExecutor.Execute(command);

            return new DeleteWalletResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Wallet>(walletFromDB)
            };
        }
    }
}
