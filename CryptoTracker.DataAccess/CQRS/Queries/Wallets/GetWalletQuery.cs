using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Wallets
{
    class GetWalletQuery : QueryBase<Wallet>
    {
        public int Id { get; set; }
        public override async Task<Wallet> Execute(CryptoStorageContext context)
        {
            return await context.Wallets.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
