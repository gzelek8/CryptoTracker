using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Transactions
{
    class GetTransactionQuery : QueryBase<Transaction>
    {
        public int Id { get; set; }
        public override async Task<Transaction> Execute(CryptoStorageContext context)
        {
            return await context.Transactions.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
