using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Wallets
{
    public class DeleteWalletCommand : CommandBase<Wallet, Wallet>
    {
        public override async Task<Wallet> Execute(CryptoStorageContext context)
        {
            context.Wallets.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
