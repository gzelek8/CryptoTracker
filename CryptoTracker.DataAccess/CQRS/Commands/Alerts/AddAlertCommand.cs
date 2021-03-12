using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Alerts
{
    public class AddAlertCommand : CommandBase<Alert, Alert>
    {
        public async override Task<Alert> Execute(CryptoStorageContext context)
        {
            await context.Alerts.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
