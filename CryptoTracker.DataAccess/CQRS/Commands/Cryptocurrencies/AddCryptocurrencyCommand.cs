using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Cryptocurrencies
{
    class AddCryptocurrencyCommand : CommandBase<Cryptocurrency, Cryptocurrency>
    {
        public override async Task<Cryptocurrency> Execute(CryptoStorageContext context)
        {
            await context.Cryptocurrencies.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
