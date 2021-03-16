using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Alerts
{
    public class GetAlertsQuery : QueryBase<List<Alert>>
    {
        public decimal PriceAlert { get; set; }
        public int? CryptocurrencyId { get; set; }
        public int? UserId { get; set; }
        public override Task<List<Alert>> Execute(CryptoStorageContext context)
        {
            if (CryptocurrencyId != null)
            {
                return context.Alerts.Where(x => x.CryptocurrencyId == this.CryptocurrencyId).ToListAsync();

            }
            else if (UserId != null)
            {
                return context.Alerts.Where(x => x.UserId == this.UserId).ToListAsync();
            }
            else if (PriceAlert != 0)
            {
                return context.Alerts.Where(x => x.PriceAlert == this.PriceAlert).ToListAsync();
            }
            else
            {
                return context.Alerts.ToListAsync();
            }
        }
    }
}
