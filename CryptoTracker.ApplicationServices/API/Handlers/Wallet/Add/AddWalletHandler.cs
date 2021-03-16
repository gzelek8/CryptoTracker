using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Add;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Wallets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Wallet.Add
{
    public class AddWalletHandler : IRequestHandler<AddWalletRequest, AddWalletResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddWalletHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddWalletResponse> Handle(AddWalletRequest request, CancellationToken cancellationToken)
        {
            var wallet = this.mapper.Map<DataAccess.Entities.Wallet>(request);
            var command = new AddWalletCommand()
            {
                Parameter = wallet
            };
            var walletformDb = await this.commandExecutor.Execute(command);

            return new AddWalletResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Wallet>(walletformDb)
            };

        }
    }
}
