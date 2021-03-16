using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Cryptocurrencies
{
    public class PutCryptocurrencyCommand : CommandBase<Cryptocurrency, Cryptocurrency>
    {
        public override async Task<Cryptocurrency> Execute(CryptoStorageContext context)
        {
            context.Cryptocurrencies.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
