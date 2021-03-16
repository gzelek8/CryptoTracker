using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Alerts
{
    public  class DeleteAlertCommand : CommandBase<Alert, Alert>
    {
        public override async Task<Alert> Execute(CryptoStorageContext context)
        {
            context.Alerts.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
