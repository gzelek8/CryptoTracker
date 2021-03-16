using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Alert
{
    public class GetAlertsRequest : IRequest<GetAlertsResponse>
    {
        public decimal PriceAlert { get; set; }
        public int? CryptocurrencyId { get; set; }
        public int? UserId { get; set; }

    }
}
