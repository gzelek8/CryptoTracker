using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Transactions
{
    public class GetTransactionsQuery : QueryBase<List<Transaction>>
    {
        public int? CryptocurrencyId { get; set; }
        public int? UserId { get; set; }
        public double CryptoAmount { get; set; }

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
            else if (CryptoAmount != 0)
            {
                return context.Transactions.Where(x => x.CryptoAmout == this.CryptoAmount).ToListAsync();
            }
            else
            {
                return context.Transactions.ToListAsync();
            }
        }
    }
}