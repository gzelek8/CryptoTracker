using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Cryptocurrencies
{
    public class GetCryptocurrencyQuery : QueryBase<Cryptocurrency>
    {
        public int Id { get; set; }
        public override async Task<Cryptocurrency> Execute(CryptoStorageContext context)
        {
            return await context.Cryptocurrencies.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
