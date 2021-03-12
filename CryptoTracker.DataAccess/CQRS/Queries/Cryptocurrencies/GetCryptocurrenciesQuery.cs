using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Cryptocurrencies
{
    class GetCryptocurrenciesQuery : QueryBase<List<Cryptocurrency>>
    {
        public string Name { get; set; }

        public override Task<List<Cryptocurrency>> Execute(CryptoStorageContext context)
        {
            if (this.Name != null)
            {
                return context.Cryptocurrencies.Where(x => x.Name == this.Name).ToListAsync();
            }
            else
            {
                return context.Cryptocurrencies.ToListAsync();
            }
        }
    }
}
