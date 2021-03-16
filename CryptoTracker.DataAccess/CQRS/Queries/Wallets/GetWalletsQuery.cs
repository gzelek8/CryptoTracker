using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Wallets
{
    public class GetWalletsQuery : QueryBase<List<Wallet>>
    {
        public int? UserId { get; set; }
        public override async Task<List<Wallet>> Execute(CryptoStorageContext context)
        {

            if (UserId != null)
            {
                return await context.Wallets.Where(x => x.UserId == this.UserId).ToListAsync();
            }
            else
            {
                return await context.Wallets.ToListAsync();
            }


        }

    }
}
