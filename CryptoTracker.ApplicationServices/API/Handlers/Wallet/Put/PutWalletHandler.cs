using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Put;
using CryptoTracker.DataAccess.CQRS;
using CryptoTracker.DataAccess.CQRS.Commands.Wallets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Handlers.Wallet.Put
{
    public class PutWalletHandler : IRequestHandler<PutWalletRequest, PutWalletResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutWalletHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutWalletResponse> Handle(PutWalletRequest request, CancellationToken cancellationToken)
        {
            var wallet = this.mapper.Map<DataAccess.Entities.Wallet>(request);
            var command = new PutWalletCommand()
            {
                Parameter = wallet
            };
            var walletdromDb = await this.commandExecutor.Execute(command);

            return new PutWalletResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Wallet>(walletdromDb)
            };
        }
    }
}
