using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Transactions
{
    class AddTransactionCommand : CommandBase<Transaction, Transaction>
    {
        public override async Task<Transaction> Execute(CryptoStorageContext context)
        {
            await context.Transactions.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
