using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CryptoTracker.DataAccess.CQRS.Commands.Transactions
{
    class DeleteTransactionCommand : CommandBase<Transaction, Transaction>
    {
        public override async Task<Transaction> Execute(CryptoStorageContext context)
        {
            context.Transactions.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
