using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Transactions
{
    class GetTransactionsQuery : QueryBase<List<Transaction>>
    {
        public int? CryptocurrencyId { get; set; }
        public int? UserId { get; set; }

        public override Task<List<Transaction>> Execute(CryptoStorageContext context)
        {
            if (CryptocurrencyId != null)
            {
                return context.Transactions.Where(x => x.CryptocurrencyId == this.CryptocurrencyId).ToListAsync();
            }
            else if (UserId != null)
            {
                return context.Transactions.Where(x => x.UserId == this.UserId).ToListAsync();
            }
            else
            {
                return context.Transactions.ToListAsync();
            }
        }
    }
}