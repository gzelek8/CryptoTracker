using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Cryptocurrencies
{
    public class GetCryptocurrenciesQuery : QueryBase<List<Cryptocurrency>>
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public decimal Price { get; set; }

        public override Task<List<Cryptocurrency>> Execute(CryptoStorageContext context)
        {
            if (this.Name != null)
            {
                return context.Cryptocurrencies.Where(x => x.Name == this.Name).ToListAsync();
            }
            else if (this.Rank != 0)
            {
                return context.Cryptocurrencies.Where(x => x.Rank == this.Rank).ToListAsync();
            }
            else if (this.Price != 0)
            {
                return context.Cryptocurrencies.Where(x => x.Price == this.Price).ToListAsync();
            }
            else
            {
                return context.Cryptocurrencies.ToListAsync();
            }
        }
    }
}
