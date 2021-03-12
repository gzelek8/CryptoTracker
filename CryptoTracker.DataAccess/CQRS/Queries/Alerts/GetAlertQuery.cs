using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Alerts
{
    public class GetAlertQuery : QueryBase<Alert>
    {
        public int Id { get; set; }
        public override async Task<Alert> Execute(CryptoStorageContext context)
        {
            return await context.Alerts.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
